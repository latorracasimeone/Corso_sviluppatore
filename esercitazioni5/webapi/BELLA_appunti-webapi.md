SCARICA ESTENSIONE SQLITE VIEWER

# WEBAPI RUBRICA COMPLETA V1

# Pacchetti da installare
Creazione archetipo webapi
```bash
dotnet new webapi -o "Rubrica.Api"
```
## Installazione globale di EF:
- Se non hai dotnet ef
```bash
dotnet tool install --global dotnet-ef
```

## Pacchetti neccessari per il progetto:
- Entity Framework Core e SQLite:
```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
```
- Strumenti per migrazioni:
```bash
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
```
- Per identity con EF Core:
```bash
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
```
- JWT e autenticazione:
```bash
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package System.IdentityModel.Tokens.Jwt
```
## Migrazioni:
Le Migrations vengono generate automaticamente da Entity Framework con un comando nel terminale console:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```
gestiscono modifiche schema database. (tutti i comandi legati ad Entity Framework avranno dopo il dotnet la sigla ef)

CERCARE Chocolatey

VERIFICARE INSTALLAZIONI SU FILE .CSPROJ



- ApplicationUser che estende IdentityUser
- Tabella Interest collegata all'utente
- AuthService
- InterestService
- controller semplici con operazioni CRUD

```bash
Rubrica.Api
│
├ Controllers
│  ├ AuthController.cs
│  └ InterestsController.cs
│
├ Data
│  └ ApplicationDbContext.cs
│
├ Dtos
│  ├ AuthResponseDto.cs
│  ├ InterestCreateDto.cs
│  ├ InterestDto.cs
│  ├ LoginDto.cs
│  └ RegisterDto.cs
│
├ Helpers
│  └ JwtHelper.cs
│
├ Models
│  ├ ApplicationUser.cs
│  └ Interest.cs
│
├ Services
│  ├ AuthService.cs
│  └ InterestService.cs
│
├ Program.cs
└ appsettings.json
```

## Models
- ApplicationUser.cs:
Estende IdentityUser, che è la classe base di Identity, per rappresentare un utente. Aggiungiamo alcune proprietà personalizzate (come, ad esempio: NomeCompleto, CreatedAt e la lista interessi Interests). Viene mappata alla tabella "Users" nel database e ha una relazione uno-a-molti con Interests.
```c#
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rubrica.Api.Models;

[Table("Users")] //decorator che ci permette di segnalare che è una tabella User (la tabella di apparteneneza della classe)
public class ApplicationUser : IdentityUser // rapporto "figlio : padre", difatti ciò che contiene IdentityUser viene inserito automaticamente in ApplicationUser per ereditarietà!!!!!!!
{
    //IdentityUser ha gia:
    // Id, Username, Email, PasswordHash, PhoneNumber, ecc.

    [Required]
    [StringLength(100)]
    public string NomeCompleto { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    //un utente può avere molteplici interessi
    public List<Interest> Interests { get; set; } = new List<Interest>(); //lista di oggetti
}
```

- Interest.cs:
Rappresenta un oggetto dell'utente, con un nome e un collegamento all'utente alla quale appartiene. Viene mappato alla tabella "Interests" nel database ed ha una relazione molti-a-uno con ApplicationUser.
```c#
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rubrica.Api.Models;

[Table("Interests")]
public class Interest
{
    public int id { get; set; }

    [Required]
    [StringLength(100)]
    public string Nome { get; set; } = string.Empty;

    //con identity l'id utente è string poiché un codice alfanumerico molto lungo (e quindi più sicuro)
    [Required]
    public string UserId { get; set; } = string.Empty;

    //collegamento all'utente
    [ForeignKey("UserId")]
    public ApplicationUser? User { get; set; } //il punto di domanda serve per dare possibile valore null e togliere gli errori, come ti aveva fatto fare Spazzo
}
```

## Dtos


- RegisterDto.cs:
Serve per fornire i dati necessari alla registrazione di un nuovo utente. Viene usato come input per l'endpoint di registrazione (per l'appunto REGISTERdto) nell'AuthController.
```c#
using System.ComponentModel.DataAnnotations;

namespace Rubrica.Api.Dtos;

public class RegisterDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [StringLength(100, MinimumLength = 6)]
    public string Password { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string NomeCompleto { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;
}
```

- LoginDto.cs:
Serve per fornire i dati necessari al login di un utente esistente. Viene usato come input per l'endpoint di login nell'AuthController.
```c#
using System.ComponentModel.DataAnnotations;

namespace Rubrica.Api.Dtos;

public class LoginDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    //non serve lo stringlength perché deve confrontare con l'originale, quindi poco ci cambia se inserisce 6k caratteri, dato che il limite imposto dal decorators lo ha già l'originale nella quale viene creata la password
    public string Password { get; set; } = string.Empty;
}
```

- AuthResponseDto.cs:
Serve per restituire i dati di risposta dopo una registrazione o un login riusciti. Contiene il Token JWT generato, l'id dell'utente, l'email e il nome completo. Viene usato come output per gli endpoint di registrazione e login nell'AuthController.

```c#
namespace Rubrica.Api.Dtos;

public class AuthResponseDto //risponde a seconda del logindto
{
    public string Nome { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string NomeCompleto { get; set; } = string.Empty;
}
```

- InterestCreateDto.cs:
Serve per fornire i dati necessari alla creazione o aggiornamento di un interesse. Viene usato come input per gli endpoint di creazione e aggiornamento degli interessi nell'InterestController.
```c#
using System.ComponentModel.DataAnnotations;

namespace Rubrica.Api.Dtos;

public class InterestCreateDto
{
    [Required]
    [StringLength(100)]
    public string Nome { get; set; } = string.Empty;
}
```

- InterestDto.cs:
Serve per restituire i dati di un interesse. Contiene l'id e il nome dell'interesse. Viene usato come output per gli endpoint di lettura degli interessi nell'InterestController.
```c#
namespace Rubrica.Api.Dtos

public class InterestDto
{
    public int id { get; set; }
    public string Nome { get; set; } = string.Empty;
}
```

## Data
- File ApplicationDbContext.cs:
Il DbContext è la classe principale di Entity Framework che gestisce la connessione al database e le operazioni CRUD che vengono eseguite sulle entità dei services dell'applicazione. In questo caso, ApplicationDbContext estende IdentytyUserContext per integrare Identity con il nostro modello di utente personalizzato e aggiunge un DbSet cioà per gestire la tabella degli interessi.
```c#
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rubrica.Api.Models;

namespace Ribrica.Api.Data;

public class ApplicationDbContext : IdentityUserContext<ApplicationUser>
{
    //questo DbContext usa Identity solo per gli utenti
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        //qui non serve aggiungere niente, il costruttore base si occupa di configurare il dbcontext con le opzioni fornite in Programs
    }

    //e in più aggiunge gli interessi
    public DbSet<Interest> Interests { get; set; }
}
```

## Helpers
- JwtHelper.cs:
JwtHelper è una classe di utilità che si occupa di generare token JWT per l'autenticazione degli utenti. Legge la chiave segreta l'emittente e ci lo sta ricevendo dal file di configurazione appsettings.json, e crea un token JWT che include alcune informazioni dell'utente come id, username ed email. Il token viene firmato con HMAC SHA256 per garantire la sicurezza.

Il token viene generato automaticamente quando viene effettuato il login, e poi viene restituito al client Angular che lo userà per autenticarsi nelle richieste successive. 
```c#
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Rubrica.Api.Models;

namespace Rubrica.Api.Helpers;

public class JwtHelper
{
    private readonly IConfiguration _configuration;

    public JwtHelper(IConfiguration configuration)
    {
        _configuration = configuration; //come in php, è una convenzione per vedere a prima vista qual è la variabile privata (quindi con l'underscore _prima) e quale la pubblica (senza underscore prima)
    }

    public string GenerateToken(ApplicationUser user)
    {
        //leggiamo i dati del file appsettings.json
        string? key = _configuration["Jwt:Key"];
        string? issuer = _configuration["Jwt:Issuer"];
        string? audience = _configuration["Jwt:Audience"];

        if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(issuer) || string.IsNullOrEmpty(audience)) //il || si fa con il tasto prima dell'uno nella tastiera e significa OR, OPPURE
        {
            throw new Exception("Configurazione JWT mancante.");
        }

        // Dentro il token mettiamo alcune informazioni utili
        Claim[] claims = new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName ?? ""),
            new Claim(ClaimTypes.Email, user.Email ?? "")
        };

        SymmetricSecurityKey securityKey = new SymetricSecurityKey(Encoding.UTF8.GetBytes(key));//UTF8 è la famiglia di caratteri
        SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.Hmac5ha256);//Il token viene firmato con HMAC SHA256 per garantire la sicurezza.

        JwtSecurityToken token = new JwtSecurityToken(
            issuer : issuer,
            audience : audience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1), //scadenza semplificata
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
```

## Services
- AuthService.cs:
Auth service che gestisce la logica di registrazione e login degli utenti, utilizzando UserManager e SignInManager di Identity per interagire con il database degli utenti e JwtHelper per generare i token JWT.
```c#
using Microsoft.AspNetCore.Identity;
using Rubrica.Api.Dtos;
using Rubrica.Api.Helpers;
using Rubrica.Api.Models;

namespace Rubrica.Api.Services;

public class AuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly JwtHelper _jwtHelper;

    public AuthService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        JwtHelper jwtHelper)
    {
        _usermanager = usermanager;
        _signInManager = signInManager;
        _jwtHelper = jwtHelper;
    }
    
    ///questo è un metodo asincrono che restituisce un IdentityResult, che indica se la registrazione è riuscita o no
    /// e contiene eventuali errori e un metodo asincrono che è un metodo che può essere eseguito in modo non bloccante
    /// cioè può fare operazioni che richiedono tempo (come accedere al database)
    /// senza bloccare il thread principale dell'applicazione
    public async Task<IdentityResult> RegisterAsync(RegisterDto dto)
    {
        //controlliamo se esiste già un utente con questa email
        ApplicationUser? existingUser = await _userManager.FindByEmailAsync(dto.Email); //await fa restare in attesa il thread finché l'operazione non è completa, sono da usare insieme await e async

        if (existingUser != null)
        {
            IdentityError error = new IdentityError();
            error.Description = "Email già registrata.";

            List<IdentityError> errors = new List<IdentityError>();
            errors.Add(error);

            return IdentityResult.Failed(errors.ToArray());
        }

        //Creiamo il nuovo utente
        ApplicationUser user = new ApplicationUser();
        user.UserName = dto.Email; //usiamo la mail anche come username, come fanno molti siti
        user.Email = dto.Email;
        user.NomeCompleto = dto.NomeCompleto;
        user.PhoneNumber = dto.PhoneNumber;
        user.CreatedAt = DateTime.UtcNow;

        //identity salva l'utente e crea l'hash sicuro della password
        IdentityResult result = await _userManager.CreateAsync(user, dto.Password);

        return result;
    }
    public async Task<AuthResponseDto?> LoginAsync(LoginDto dto)
    {
        //cerchiamo l'utente per email
        ApplicationUser? user = await _userManager.FindByEmailAsync(dto.Email);

        if (user == null)
        {
            return null;
        }

        //Controlliamo se la password è giusta
        SignInResult result = await _userManager.CheckPasswordSignInAsync(user, dto.Password, false);
        
        if (!result.Succeeded)
        {
            return null;
        }

        //se tutto va bene creiamo il token
        string token = _jwtHelper.GenerateToken(user);

        AuthResponseDto response = new AuthResponseDto();
        response.Token = token;
        response.UserId = user.Id;
        response.Email = user.Email ?? "";
        response.NomeCompleto = user.NomeCOmpleto;

        return response;
    }
}
``` 
- InterestService.cs:
InterestService gestisce la logica di business per le operazioni CRUD sugli interessi degli utenti. Utilizza ApplicationDbContext per interagire con il database e implementa metodi asincroni per ottenere, creare, aggiornare e cancellare interessi, assicurandosi che ogni operazione sia autorizzata solo per l'utente a cui appartiene l'interesse.
```c#
using Rubrica.Api.Data;
using Rubrica.Api.Dtos;
using Rubrica.Api.Models;

namespace Rubrica.Api.Services;

public class InterestService
{
    private readonly ApplicationDbContext _context;

    public InterestService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<InterestDto>> GetAllByUserIdAsync(string userId)
    {
        List<InterestDto> result = new List<InterestDto>();

        //prendiamo tutti gli interessi dal database
        List<Interest> allInterests = _context.Interests.ToList();

        //filtriamo a mano solo quelli dell'utente loggato
        for (int i = 0; i < allInterests.Count; i++)
        {
            Interest currentInterest = allInterests[i];

            if (currentInterest.UserId == userId)
            {
                InterestDto dto = new InterestDto();
                dto.Id = currentInterest.Id;
                dto.Nome = currentInterest.Nome;

                result.Add(dto);
            }
        }
        return await Task.FromResult(result);
    }
    public async Task<InterestDto?> GetByIdAsync(int id, string userId)
    {
        Interest? interest = await _context.Interests.FindAsync(id);

        if (interest == null)
        {
            return null;
        }

        //Controlliamo che l'interesse appartenga all'utente giusto
        if (Interest.UserId != userId)
        {
            return null;
        }

        InterestDto dto = new InterestDto();
        dto.Id = Interest.Id;
        dto.Nome = Interest.Nome;

        return dto;
    }

    public async Task<InterestDto?> CreateAsync(InterestCreateDto dto, string userId)
    {
        //controllo semplice per evitare doppioni
        List<Interest> allInterests = _context.Interests.ToList();
        for (int i = 0; i < allInterests.Count; i++)
        {
            Interest currentInterest = allInterests[i];
            if (currentInterest.UserId == userId && currentInterest.Nome == dto.Nome)
            {
                return null;
            }
        }
        Interest interest = new Interest();
        interest.Nome = dto.Nome;
        interest.UserId = userId;

        _context.Interests.Add(interest);
        await _context.SaveChangesAsync();

        InterestDto result = new InterestDto();
        result.Id = interest.Id;
        result.Nome = interest.Nome;

        return result;
    }

    public async Task<InterestDto?> UpdateAsync(int id, InterestCreateDto dto, string userId)
    {
        Interest? interest = await _context.Interests.FindAsync(id);

        if (interest == null)
        {
            return null;
        }
        if (interest.UserId != userId)
        {
            return null;
        }
        interest.Nome = dto.Nome;
        await _context.SaveChangesAsync();
        InterestDto result = new InterestDto();
        result.Id = interest.Id;
        result.Nome = interest.Nome;
        return result;
    }

    public async Task<bool> DeleteAsync(int id, string userId)
    {
        Interest? interest = await _context.Interests.FindAsync(id);

        if (interest == null)
        {
            return false;
        }
        if (interest.UserId != userId)
        {
            return false;
        }

        _context.Interests.Remove(interest);
        await :context.SaveChangesAsync();

        return true;
    }
}
```

## Controllers
- AuthController.cs:
In questa applicazione i controller gestiscono solamente le richieste HTTP e restituiscono le risposte. AuthController si occupa di gestire le operazioni di registrazione e login degli utenti, utilizzando AuthService per eseguire la logica di business e restituendo i risultati al client Angular.
```c#
using Microsoft.AspNetCore.Mvc;
using Rubrica.Api.Dtos;
using Rubrica.Api.Services;

namespace Rubrica.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        var result = await _authService.RegisterAsync(dto);

        if (!result.Succeeded)
        {
            List<string> errors = new List<string>();

            foreach (var error in result.Errors)
            {
                errors.Add(error.Description);
            }

            return BadRequest(errors);
        }
        return Ok(new { message = "Registrazione completata." });

    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        AuthResponseDto? response = await _authService.LoginAsync(dto);

        if (response == null)
        {
            return Unauthorized(new { message = "Email o password non validi."});
        }
        return Ok(response);
    }
}
```

- InterestsController.cs:
InterestsController gestisce le operazioni CRUD sugli interessi degli utenti. Utilizza InterestService per eseguire la logica di business e restituisce i risultati al client Angular. Tutti gli endpoint sono protetti con l'attributo '[Authorize]', quindi è necessario essere autenticati con un token JWT valido per accedervi.
```c#
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rubrica.Api.Dtos;
using Rubrica.Api.Services;

namespace Rubrica.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class InterestsController : ControllerBase
{
    private readonly InterestService _interestService;

    public InterestsController(InterestService interestService)
    {
        _interestService = interestService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        string userId = GetUserIdFromToken();

        List<InterestDto> interests = await _interestService.GetAllByUserIdAsync(userId);

        return Ok(interests);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        string userId = GetUserIdFromToken();

        InterestDto? interest = await _interestService.GetByIdAsync(id, userId);

        if (interest == null)
        {
            return NotFound(new { message = "Interesse non trovato."});
        }

        return Ok(interest);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] InterestCreateDto dto)
    {
        string iserId = GetUserIdFromToken();

        InterestDto? result = await _interestService.CreateAsync(dto, userId);

        if (result == null)
        {
            return BadRequest(new { message = "Interesse già presente oppure non valido."});
        }

        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] InterestCreateDto dto)
    {
        string userId = GetUserIdFromToken();

        InterestDto? result = await _interestService.UpdateAsync(id, dto, userId);

        if (result == null)
        {
            return NotFound(new { message = "Interesse non trovato."});
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        string userId = GetUserIdFromToken();

        bool deleted = await _interestService.DeleteAsync(id, userId);

        if (!deleted)
        {
            return NotFound(new { message = "Interesse non trovato."});
        }

        return NoContent();
    }

    private string GetUserIdFromToken()
    {
        //leggiamo l'id utente che abbiamo salvato nel jwt
        string? userId = User.FindFirstValue(CLaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userId))
        {
            throw new Exception("UserId non trovato nel token.");
        }
        return userId;
    }
}
```

## - Program.cs:

```c#
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNeyCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Rubrica.Api.Data;
using Rubrica.APi.Dtos;
using Rubrica.Api.Helpers;
using Rubrica.Api.Models;
using Rubrica.Api.Services;


var builder = WebApplication.CreateBuilder(args);//

//aggiunge i controller
builder.Services.AddControllers();

//configura EntityFramework Core con Sqlite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//configura identity per gli utenti
builder.Services.AddIdentityCore<ApplicationUser>(options =>
{
    //regole password semplici per fare pratica
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercas = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
})
.AddSignInManager<SignInManager<ApplicationUser>>()
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

//configurazione JWT
string? jwtKey = builder.Configuration["Jwt:Key"];
string? jwtIssuer = builder.Configuration["Jwt:Issuer"];
string? jwtAudience = builder.Configuration["Jwt:Audience"];

if (string.IsNullOrEmpty(jwtKey) || string.IsNullOrEmpty(jwtIssuer) || string.IsNullOrEmpty(jwtAudience))
{
    throw new Exception("Configurazione JWT mancante in appsettings.json");
}

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = nel TokenValidationParameters
        {
            ValidateIssuer = true, //Controlla che il token sia stato emesso dall'issuer corretto
            ValidateAudience = true, //Controlla che il token sia destinato all'audience corretta
            ValidateLifetime = true, //Controlla che il token non sia scaduto
            ValidateIssuerSigningKey = true, //Controlla la firma del token
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });
///[leggiamo la chiave JWT da appsettings] (tutto commento per non inficiare nel codice se venisse copiato per intero). è LA VERSIONE ABBREVIATA DEL PUNTO "configurazione JWT":
//var jwtKey = builder.Configuration["Jwt:Key"]
//             ?? throw new Exception("Jwt:Key mancante in appsettings.json");



//abilita autorizzazione
builder.Services.AddAuthorization();

//configura CORS per permettere ad Angular in locale di chiamare l'API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});



//registrazione servizi custom
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<InterestService>();
builder.Services.AddScoped<JwtHelper>();

var app = builder.Builde();

app.UseCors("AllowAngularApp");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

//Applica automaticamente le migration all'avvio
using (var scope = app.Services.CreateScope())
{
    var db = scoper.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}

//richiama il seed iniziale con alcuni utenti demo e i loro interessi.
//se i dati esistono già, non vengono duplicati.
await DataSeeder.SeedAsync(app.Services);


app.Run();
```
DA VEDERE:: //Configurazione autenticazione JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            
            ValidateIssuer = true,

            
            ValidateAudience = true,

            
            ValidateLifetime = true,

            
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });



## Seed
- DataSeeder.cs:
DataSeeder è una classe statica che si occupa di popolare il database con dati iniziali per facilitare i test e lo sviluppo. il metodo SeedAsync crea alcuni utenti demo e interessi associati a quegli utenti, ma prima controlla se esistono già per evitare duplicazioni. Viene chiamato all'avvio dell'applicazione dopo aver applicato le migrazioni del database.
```c#
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Rubrica.Api.Data;
using Rubrica.Api.Models;

namespace Rubrica.Api.Seed;

public static class DataSeeder
{
    //questo metodo crea utenti e interessi iniziali. se i dati esistono già, non li duplica
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        using IServiceScope scope = service.Provider.CreateScope();

        ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        UserManager<ApplicationUser> userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        //creiamo il database se non esiste ancora
        await context.Database.EnsureCreatedAsync();

        //creiamo alcuni utenti demo
        ApplicationUSer utente1 = await CreateUserIfNotExistAsync(
            userManager,
            "utente1@email.com",
            "123456",
            "Utente uno",
            "1234567898765432");

        ApplicationUSer utente2 = await CreateUserIfNotExistAsync(
            userManager,
            "utente2@email.com",
            "123456",
            "Utente due",
            "12345678765432");

        ApplicationUSer utente3 = await CreateUserIfNotExistAsync(
            userManager,
            "utente3@email.com",
            "123456",
            "Utente tre",
            "12345765432");


        //creiamo alcuni interessi per ogni utente
        await CreateInterestIfNotExistsAsync(context, utente1.Id, "calcio");
        await CreateInterestIfNotExistsAsync(context, utente1.Id, "cinema");
        await CreateInterestIfNotExistsAsync(context, utente1.Id, "kratos");

        await CreateInterestIfNotExistsAsync(context, utente2.Id, "F1");
        await CreateInterestIfNotExistsAsync(context, utente2.Id, "auto");
        await CreateInterestIfNotExistsAsync(context, utente2.Id, "simulatore");

        await CreateInterestIfNotExistsAsync(context, utente3.Id, "Hulk");
        await CreateInterestIfNotExistsAsync(context, utente3.Id, "Superman");
        await CreateInterestIfNotExistsAsync(context, utente3.Id, "Lex Luthor");
    }

    private static async Task<ApplicationUser> CreateUserIfNotExistsAsync(
        UserManager<ApplicationUser> userManager,
        string email,
        string password,
        string nomeCompleto,
        string? phoneNumber)
    {
        //controlliamo se l'utente esiste già tramite email
        ApplicationUser? existingUser = await userManager.FindByEmailAsync(email);

        if (existingUser != null)
        {
            return existingUser;
        }

        ApplicationUSer user = new ApplicationUser();
        user.UserName = email;
        user.Email = email,
        user.NomeCompleto = nomeCompleto,
        user.PhoneNumber = phoneNumber,
        user.CreatedAt = DateTime.UtcNow;

        IdentityResult result = await userManager.CreateAsync(user, password);

        if (!result.Succeeded)
        {
            List<string> errors = new List<string>();

            foreach (IdentityError error in result.Errors)
            {
                errors.Add(error.Description);
            }

            string message = string.Join(" | ", errors);
            throw new Exception($"Errore durante la creazione dell'utente {email} : {message}");
        }
        return user;
    }
    private static async Task CreateInterestIfNotExistsAsync(
        ApplicationDbContext context,
        string userId,
        string nome)
    {
        //leggiamo tutti gli interessi e controlliamo a mano se questo interesse esiste già per quell'utente.
        List<Interest> interests = await context.Interests.ToListAsync();

        for (int = 0; i < interests.Count; i++)
        {
            Interest currentInterest = interests[i];

            bool sameUser = currentInterest.UserId == userId;
            bool sameName = string.Equals(currentInterest.Nome, nome, StringComparison.OrdinalIgnoreCase);

            if (sameUser && sameName)
            {
                return;
            }
        }

        Interest interest = new Interest();
        interest.UserId = userId;
        interest.Nome = nome;

        context.Interests.Add(interest);
        await context.SaveChanges.Async();
    }
}
```

## appsettings.json
```c#
{
    "ConnectionStrings": {
        "DefaultConnection": "Data Source=rubrica.db"
    },
    "Jwt": {
        "Key": "questa-e-una-chiave-molto-lunga-di-almeno-32-caratteri",
        "Issuer": "RubricaApi",
        "Audience": "RubricaAngular"
    },
    "Logging": {
        "LogLevel": {
            "Default": "Information",
            "Microsoft.AspNetCore": "Warning"
        }
    },
    "AllowedHosts": "*"
}
```

