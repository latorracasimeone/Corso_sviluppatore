using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rubrica.Api.Dtos;
using Rubrica.Api.Models;
using Rubrica.Api.Services;

//si occupa di gedstione richieste HTTP e restituisce risposte agli endpoint interessati
namespace Rubrica.Api.Controllers;

[ApiController] // Indica che la classe risponde alle richieste API e abilita comportamenti automatici

[Route("api/[controller]")]

[Authorize]/*Questo attributo a livello di classe dice ad ASP.NET Core: "Nessuno può toccare questi 
metodi se non ha un token JWT valido". Senza questo, il tuo metodo GetUserIdFromToken fallirebbe quasi sempre.*/
public class InterestsController : ControllerBase
{
    private readonly InterestService _interestService; /*L' underscore è una convenzione (non una regola obbligatoria
     del linguaggio) per distinguere a colpo d'occhio i campi privati della classe dalle variabili locali dei metodi.*/

    public InterestsController(InterestService interestService) /*costruttore (difatti si chiama uguale alla classe) che
     riceve il servizio (InterestService) istanziato da ASP.NET core tramite iniezione (Dependency Injection). Riceve 
     oggetti senza doverli creare, quindi non è necessario scrivere "new InterestService()", ci pensa il framework come Comportamento automatico*/
    {
        _interestService = interestService; /*l'underscore sta a significare (per convenzione) che si rifà alla parte privata, privata 
        perché solo questa classe deve poter usare quel servizio (_interestService), per sicurezza che faccia questa
        cosa dedicata con tali responsabilità) e pulizia (del codice)*/
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() //Recupera tutti gli interessi associati all'utente autenticato.
    {
        string userId = GetUserIdFromToken();

        List<InterestDto> interests = await _interestService.GetAllByUserIdAsync(userId);

        return Ok(interests); //Ritorna 200 OK con la lista
    }

    [HttpGet("{id}")]// Recupera un singolo interesse tramite ID, verificando che appartenga all'utente.
    public async Task<IActionResult> GetById(int id)
    {
        string userId = GetUserIdFromToken();

        InterestDto? interest = await _interestService.GetByIdAsync(id, userId);

        if (interest == null)
        {
            return NotFound(new { message = "Interesse non trovato." }); //ERROR 404 NOT FOUND
        }

        return Ok(interest); //200  OK
    }

    //Crea un nuovo interesse per l'utente autenticato
    [HttpPost] /* POST api/interests. :
    Poiché la rotta base è [Route("api/[controller]")] 
    (quindi api/interests) e il metodo Create non ha stringhe aggiuntive nel [HttpPost], 
    l'URL finale sarà esattamente api/interests. */
    [Authorize(Roles = UserRoles.AdminOrEditor)]
    public async Task<IActionResult> Create([FromBody] InterestCreateDto dto)
    {
        string userId = GetUserIdFromToken();

        InterestDto? result = await _interestService.CreateAsync(dto, userId);

        if (result == null)
        {
            return BadRequest(new { message = "Interesse già presente oppure non valido." });// ERROR 400
        }

        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);// Ritorna 201 Created e indica l'URL per recuperare la risorsa appena creata
    }

    //COME SAREBBE PIù CORRETTO E PROFESSIONALE PER AVERE ANCHE UNA TABELLA XML PER LA DOCUMENTAZIONE::
    /// <summary>
    /// Aggiorna un interesse esistente.
    /// </summary>
    /// <example>
    /// 
    /// </example>
    [HttpPut("{id}")] // PUT api/interests/{id}
    [Authorize(Roles = UserRoles.AdminOrEditor)]
    public async Task<IActionResult> Update(int id, [FromBody] InterestCreateDto dto)
    {
        string userId = GetUserIdFromToken();

        InterestDto? result = await _interestService.UpdateAsync(id, dto, userId);

        if (result == null)
        {
            return NotFound(new { message = "Interesse non trovato." });//ERROR 404
        }

        return Ok(result);//Codice di stato HTTP 200 OK
    }


    /// Elimina un interesse specifico.
    [HttpDelete("{id}")] // DELETE api/interests/{id}
    [Authorize(Roles = UserRoles.AdminOrEditor)]
    public async Task<IActionResult> Delete(int id)
    {
        string userId = GetUserIdFromToken();

        bool deleted = await _interestService.DeleteAsync(id, userId);

        if (!deleted)
        {
            return NotFound(new { message = "Interesse non trovato." });//ERROR 404
        }

        return NoContent();/* Codice di stato HTTP 204 No Content: l'operazione è riuscita ma non c'è nulla da restituire.
        PS:È lo standard per le DELETE. Se la risorsa è stata eliminata, non ha senso rimandarla indietro nel corpo della 
        risposta. Il codice 204 conferma al client: "Ho fatto quello che hai chiesto, tutto pulito".*/
    }

    private string GetUserIdFromToken()/* Leggiamo l'id utente che abbiamo salvato nel JWT. 
        PS:Quindi l'identità dell'utente non viene passata "per fiducia" dal client (tipo un parametro nella URL che 
        chiunque potrebbe cambiare), ma viene estratta dal Token criptato e firmato. Questo garantisce che un utente
         possa vedere/modificare solo i propri interessi e non quelli di altri.*/
    {

        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userId))
        {
            throw new Exception("UserId non trovato nel token.");// Se il token è valido (grazie ad [Authorize]) ma non ha l'ID, c'è un errore di configurazione
        }

        return userId;
    }
}