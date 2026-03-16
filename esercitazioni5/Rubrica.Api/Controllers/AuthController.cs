using Microsoft.AspNetCore.Mvc;
using Rubrica.Api.Dtos;
using Rubrica.Api.Services;

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
     oggetti senza doverli creare, quindi non è necessario scrivere "new authService()", ci pensa il framework come Comportamento automatico*/
    {
        _authService = authService;/*l'underscore sta a significare (per convenzione) che si rifà alla parte privata, privata 
        perché solo questa classe deve poter usare quel servizio (_authService), per sicurezza che faccia questa
        cosa dedicata con tali responsabilità) e pulizia (del codice)*/
    }


    /// Endpoint per la registrazione di un nuovo utente.
    [HttpPost("register")] /* mappa un URL a un metodo 
    Risponde a POST(scrittura/invio) api/auth/register (rotta base(Controller) + specifica(metodo, derivato da [HttpPost("register")]))*/
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
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

            return BadRequest(errors);//Codice di stato HTTP (sbagliato) ERROR 400 BadRequest
        }

        // Restituisce Codice di stato HTTP (corretto) 200 OK in caso di successo
        return Ok(new { message = "Registrazione completata." });
    }


    /// Endpoint per l'autenticazione (login) e generazione del token.
    [HttpPost("login")] // Risponde a POST(scrittura\invio) api/auth/login (rotta base api/auth + specifica "login")
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        // Tenta l'accesso tramite il servizio dedicato (authService)
        AuthResponseDto? response = await _authService.LoginAsync(dto);

        if (response == null)
        {
            // Se le credenziali sono errate, restituisce 401 Unauthorized
            return Unauthorized(new { message = "Email o password non validi."});
        }

        // Restituisce 200 OK con i dati dell'utente e il token JWT
        return Ok(response);
    }
}