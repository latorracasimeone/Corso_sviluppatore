using Microsoft.AspNetCore.Mvc;
using Rubrica.Api.Dtos;
using Rubrica.Api.Services;
//AGGIUNTA
using System.Security.Claims;


/*I CONTROLLER si occupano di gestione richieste http e restituizione risposte, 
particolareggiando in questo caso su operazione di registrazione e login degli utenti.*/
namespace Rubrica.Api.Controllers;

[ApiController] // Indica che la classe risponde alle richieste API e abilita comportamenti automatici
[Route("api/[controller]")] // Definisce la rotta base e il nome controller: api/auth ("api/" prefisso comune per backend, "auth" è il nome rotta)
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    //il servizio di autenticazione (privato, difatti la variabile è precedunta dall'underscore per riconoscerla) viene iniettato nel costruttore

    public AuthController(AuthService authService)/*costruttore (difatti si chiama uguale alla classe) che
     riceve il servizio (authService) istanziato da ASP.NET core tramite iniezione (Dependency Injection). Riceve 
     oggetti senza doverli creare, quindi non è necessario scrivere "new authService()", ci pensa il framework come Comportamento automatico. 
     Il vantaggio principale è che il Controller non è "accoppiato" strettamente all'implementazione del servizio. 
     Se un domani volessi cambiare il modo in cui gestisci l'autenticazione, ti basterebbe cambiare la configurazione nel file Program.cs senza
     toccare il codice del Controller.*/
    {
        _authService = authService;/*l'underscore sta a significare (per convenzione) che si rifà alla parte privata (o campo privato, "private fields"), privata 
        perché solo questa classe deve poter usare quel servizio (_authService), per sicurezza che faccia questa
        cosa dedicata con tali responsabilità) e pulizia (del codice)*/
    }


    /// Endpoint per la registrazione di un nuovo utente.
    [HttpPost("register")] /* mappa un URL a un metodo 
    Risponde all'HTTP METOD "POST"(scrittura/invio), api/auth/register (rotta base(Controller) + specifica(metodo, derivato da [HttpPost("register")]))*/
    public async Task<IActionResult> Register([FromBody] RegisterDto dto) /*IActionResult: Questo tipo di ritorno è molto potente perché ti permette di 
    restituire tipi diversi (un 200 Ok, un 400 BadRequest, un 401 Unauthorized) all'interno dello stesso metodo.
    Async/Await: Nei tuoi commenti non hai menzionato l'asincronia. Quando vedi async Task<IActionResult> e await, significa che il server non si 
    "blocca" aspettando il database, ma può gestire altre richieste mentre aspetta che l'operazione di registrazione/login finisca. */
    {
        // Chiama il servizio per creare l'utente nel database
        var result = await _authService.RegisterAsync(dto);

        if (!result.Succeeded)
        {
            // Se la registrazione fallisce (es. email già esistente o password debole),
            // estrae le descrizioni degli errori e le restituisce con uno stato 400 Bad Request.
            List<string> errors = new List<string>();

            foreach (var error in result.Errors)
            {
                errors.Add(error.Description);
            }

            return BadRequest(errors);//Codice di stato HTTP (richiesta del client presenta errori) ERROR 400 BadRequest
        }

        // Restituisce Codice di stato HTTP (corretto) 200 OK in caso di successo
        return Ok(new { message = "Registrazione completata." });
    }


    /// Endpoint per l'autenticazione (login) e generazione del token.
    [HttpPost("login")] // Risponde a POST(scrittura\invio) api/auth/login (rotta base api/auth + specifica "login")
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        // Tenta l'accesso tramite il servizio dedicato (authService)
        AuthResponseDto? response = await _authService.LoginAsync(dto); /*response contiene i dati che sono in 
        AuthResponseDto, per poter restituire all'utente le informazioni dopo che è stato effettuato il login. 
        Quindi per discriminare se siamo dentro o no.
        PS:Il DTO (Data Transfer Object) serve proprio a "filtrare" cosa inviare o ricevere. 
        Invece di mandare l'intero oggetto "Utente" (che potrebbe avere dati sensibili o inutili),
        mandi solo ciò che serve (es. Token e Nome).*/

        if (response == null)
        {
            // Se le credenziali sono errate, restituisce 401 Unauthorized
            return Unauthorized(new { message = "Email o password non validi." });
        }

        // Restituisce 200 OK con i dati dell'utente e il token JWT
        return Ok(response);//quindi login effettuato con successo
    }
    //AGGIUNTE
    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateUserDto dto)
    {
        string userId = GetUserIdFromToken();

        var result = await _authService.UpdateAsync(dto, userId);


        if (result == null)
        {
            return NotFound(new { message = "Utente non trovato" });//ERROR 404
        }

        return Ok(result);//Codice di stato HTTP 200 OK
    }

    //aggiunta ulteriormente postuma

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete()
    {
        // Recuperiamo l'ID dal token (stesso metodo usato per la Put)
        string userId = GetUserIdFromToken();

        var result = await _authService.DeleteAsync(userId);

        if (result == null)
        {
            return NotFound(new { message = "Utente non trovato." });
        }

        // Restituiamo Codice di stato HTTP 200 OK o 204 No Content
        return Ok(new { message = "Account eliminato correttamente." });
    }

    //AGGIUNTA ore 11:37 18/03 STAMPA UTENTE
    [HttpGet("profile")]
    public async Task<IActionResult> Stamp()
    {
        string userId = GetUserIdFromToken();

        UserStampDto? result = await _authService.GetUserProfile(userId);

        if (result == null)
        {
            return NotFound(new { message = "Utente non trovato." }); //ERROR 404 NOT FOUND
        }

        return Ok(result); //200  OK
    }

    //aggiunta ulteriormente a parte
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
