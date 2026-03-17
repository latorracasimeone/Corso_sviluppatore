using Microsoft.AspNetCore.Identity;
using Rubrica.Api.Dtos;
using Rubrica.Api.Helpers;
using Rubrica.Api.Models;

/*I SERVICES contengono la "Logica di Business". Mentre il Controller gestisce le 
richieste HTTP, il Service si sporca le mani con i dati, decide se un'operazione è 
permessa e comunica con il database tramite Identity.

AuthService gestisce la logica di registrazione e login degli utenti, utilizzando 
UserManager e SignInManager di Identity per interagire con il database degli 
utenti e JwtHelper per generare i token JWT.*/

namespace Rubrica.Api.Services;

public class AuthService
// Campi privati per gestire utenti, accessi e creazione Token.
/* UserManager e SignInManager sono classi fornite da ASP.NET Core Identity (framework) 
che gestiscono tutta la sicurezza complessa (es. hash password).*/
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly JwtHelper _jwtHelper; // Nostra classe helper per generare il "biglietto d'ingresso" (Token)

// Anche qui usiamo la Dependency Injection: il framework ci passa gli strumenti già pronti all'uso.
    public AuthService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        JwtHelper jwtHelper)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtHelper = jwtHelper;
    }

    /*Questo è un metodo asincrono che restituisce un IdentityResult, che indica se 
    la registrazione è riuscita o no e contiene eventuali errori e un metodo asincrono 
    che è un metodo che può essere eseguito in modo non bloccante cioè può fare 
    operazioni che richiedono tempo (come accedere al database) senza bloccare il 
    thread principale dell'applicazione (grazie a await)*/
    public async Task<IdentityResult> RegisterAsync(RegisterDto dto)
    {
        // Controlliamo se esiste già un utente con questa email
        // await fa restare in attesa il thread "congelandolo" finché l'operazione non è completata, ma senza bloccarlo
        ApplicationUser? existingUser = await _userManager.FindByEmailAsync(dto.Email);

        if (existingUser != null)
        {
            IdentityError error = new IdentityError();
            error.Description = "Email già registrata.";/* Se esiste già, creiamo noi un 
            errore personalizzato da restituire al Controller.*/

            List<IdentityError> errors = new List<IdentityError>();
            errors.Add(error);

            return IdentityResult.Failed(errors.ToArray());//errore specifico di Identity
        }

        // Mappatura: trasformiamo i dati ricevuti dal DTO (quelli che arrivano dal web) 
        // nel modello ApplicationUser (quello che verrà salvato sul database).
        ApplicationUser user = new ApplicationUser();
        user.UserName = dto.Email;// usiamo la mail anche come username per semplificare
        user.Email = dto.Email;
        user.NomeCompleto = dto.NomeCompleto;
        user.PhoneNumber = dto.PhoneNumber;
        user.CreatedAt = DateTime.UtcNow;

        /* Identity salva l'utente e CreateAsync si occupa di validare la password, criptarla (hashing) 
        e salvare l'utente. Non salviamo mai la password in chiaro per motivi di sicurezza*/
        // await fa restare in attesa il thread finché l'operazione non è completata, ma senza bloccarlo
        IdentityResult result = await _userManager.CreateAsync(user, dto.Password);

        return result;
    }

    /// Metodo asincrono per il login. Riceve il DTO del Login (LoginDto) dei dati inseriti dall'utente e Restituisce 
    /// un DTO con il Token (AuthResponseDto) se le credenziali sono corrette, altrimenti null.
    public async Task<AuthResponseDto?> LoginAsync(LoginDto dto)
    {
        // Cerchiamo l'utente per l'email fornita
        ApplicationUser? user = await _userManager.FindByEmailAsync(dto.Email);

        if (user == null)
        {
            return null;//utente non trovato
        }

        /*Verifica password: CheckPasswordSignInAsync confronta la password inserita con l'hash nel DB. 
        Il terzo parametro "false" indica che non vogliamo bloccare l'account dopo troppi tentativi falliti (lockout)*/
        SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);

        if (!result.Succeeded)
        {
            return null;//Password Errata
        }

        /*Se tutto va bene creiamo un JWT (JSON Web Token).Il token permetterà all'utente 
        di fare chiamate protette senza reinserire la password ogni volta.*/
        string token = _jwtHelper.GenerateToken(user);

        //Prepariamo la risposta con solo i dati necessari da rimandare al frontend. (pacchetto unico con dati precedenti+ token e nome completo)
        AuthResponseDto response = new AuthResponseDto();
        response.Token = token;
        response.UserId = user.Id;
        response.Email = user.Email ?? "";
        response.NomeCompleto = user.NomeCompleto;

        return response;
    }
}