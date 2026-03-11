(RICOLLEGATI A RIGA 261 DELL'ALTRO DOCUMENTO DI APPUNTI
E SCARICA ESTENSIONE SQLITE VIEWER)

# WEBAPI RUBRICA COMPLETA V1

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

        SymmetricSecurityKey securityKey = new SymetricSecurityKey(Encoding.UTF8.GetBytes(key));//TF8 è la famiglia di caratteri
        SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.Hmac5ha256);

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
