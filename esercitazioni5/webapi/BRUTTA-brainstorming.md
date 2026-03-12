# WEB API
L'archetipo web api è un progetto ASP.NET Core che espone endpoint HTTP per consentire a client frontend come Angular di interagire con i dati prodotti dal backend.

Il comando per creare un'applicazione web API è:

```bash
dotnet new webapi -o "Rubrica.Api"
```
(o senza virgolette nel caso non ci fossero spazi vuoti, il .Api per differenziarlo dagli altri tipi di file simili, rubriche in questo caso.)

## Struttura tipica di una web API

```bash
Rubrica.Api
├─ Controllers
├─ Models
├─ Services
├─ Repositories
├─ Data
├─ Dtos
├─ Migrations
├─ Middleware
├─ Helpers
├─ Properties
│  └─ launchSettings.json
├─ Program.cs
└─ appsettings.json
```

## Cartelle principali:
- Controllers: Contiene i controller che gestiscono le richieste HTTP e restituiscono risposte.

- Models: Contiene le classi che rappresentano i dati e le entità del Dominio.

- Services: Contiene la logica di business e i servizi che interagiscono con i dati, cioè le operazioni CRUD e altre logiche complesse.

`CRUD sono i metodi di creazione, lettura, modifica ed eliminazione`

- Data: Contiene il contesto del database (il contesto del database contiene i percorsi per pescare i driver, NOI utilizziamo driver sqlight) e le classi di accesso dati.

- Dtos: Contiene le classi Data Transfer Object, che sono altri modelli specifici per il trasferimento dei dati tra client e server, spesso usati per evitare di esporre direttamente le entità del dominio. (cosa significherebbe esporre tutti i modelli???????)

- Migrations: Contiene le migrazioni di Entity Framework (?) per gestire le modifiche al database quando viene modificato un modello.

- Middleware: Contiene componenti middleware personalizzati per gestire richieste e risposte HTTP, ad esempio per la gestione degli errori o l'autenticazione.

- Helpers: Contiene classi di utilità e helper per operazioni comni, come la gestione dei file, la validazione personalizzata, ecc ecc.

- Properties: Contiene file di configurazione specifici del progetto, come LaunchSettings.json che definisce le configurazioni di avvio per l'applicazione.

- Program.cs: il punto d'ingresso dell'applicazione, dove viene configurato il pipeline (fatto a step, comandi in sequenza?) di esecuzione e i servizi.

- appsettings.json: il file di configurazione principale dell'applicazione, dove vengono definiti parametri come stringhe di connessione al database, chiavi API e altre impostazioni.

## Controllers

I controller sono classi che ereditano da ControllerBase e sono decorati con l'attributo [ApiController]. Ogni metodo all'interno di un controller rappresenta un endpoint HTTP e viene decorato con attributi come:
-[HttpGet]
-[HttpPost]
-[HttpPut]
-[HttpDelete]

per indicare il tipo di richiesta che gestisce.

Controller base:
```c#
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet]
    public IActionResult GetUsers()
    {
        return Ok();
    }
}
```

il controller riceve richieste tipo:
```bash
GET /api/users
```

Di solito le richieste vengono inoltrate attraverso comandi CURL o clint HTTP come Postman, oppure da un frontend Angular che consuma l'API.

## Models
I modelli rappresentano le entità del dominio e sono mappati a tabelle del database.

Ad esempio, un modello Contatto potrebbe essere:
```c#
public class Contatto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public List<ContattoInteresse> Interessi { get; set; }
}
```
quando usiamo Entity Framework Core, diventano tabelle.

## DTOs (Data Transfer Objects)

Servono per non esporre direttamente i models.
Ad esempio, potremmo avere un ContattoDto che contiene solo alcune proprietà:
```c#
public class ContattoDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cognome { get; set; }
}
```
Utile per sicurezza e controllo dati.
## Services
Qui mettiamo la logica di business, tipo le operazioni CRUD e altre logiche complesse. (quello che l'applicazione deve fare, essenzialmente.)

Ad esempio, un ContattoService potrebbe avere metodi come:
` (INSERIRE NELL'APP) `
```c#
public class ContattoService
{
    public List<Contatto>> GetAll()
    {
        ...
    }
    public Contatto GetById(int id)
    {
        ...
    }
}
```
Il service viene poi iniettato nei controller per essere usato negli endpoint(?).

## Repositories

Accesso ai dati/database.
Ad esempio, un ContattoRepository potrebbe usare Entity Framework per interagire con il database:
```c#
public class ContattoRepository
{
    private readonly ApplicationDbContext _context; 
    //mettiamo l'underscore prima dal costruttore quando è privato, mettiamo solo uno spazio prima quando è pubblica (??)
    public ContattoRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public List<Contatto> GetAll()
    {
        return _context.Contatti.ToList();
    }
}
```
separa database dalla logica.

## Data

Contiene il DbContext (è qualcosa che appartiene già all'applicazione ma lo vado a sovvrascrivere facendo un override dicendogli qualcosa ??).

Ad esempio, ApplicationDbContext potrebbe essere:
```c#
public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
}
```

il DbContext è la classe principale di Entity Framework che gestisce la connessione al database e le operazioni CRUD che vengono eseguite sulle entità dai services dell'applicazione.

## Migrations

Le Migrations vengono generate automaticamente da Entity Framework con un comando nel terminale console:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```
gestiscono modifiche schema database. (tutti i comandi legati ad Entity Framework avranno dopo il dotnet la sigla ef)

## Middleware

Per intercettare richieste globali:
- logging
- auth
- error handling

Ad esempio, un Middleware per gestire eccezioni globali:
```c#
public class ExceptionMiddleware
{
    .......
}
```

## Helpers

Funzioni utility.

Esempio:

- JWT generator

- Date formatter

- Hashing password

Nello specifico JWT sarà quello che si usa per autenticare i client Angular.



# Program.cs

Qui si configura il pipeline di esecuzione e i servizi.

Ad esempio, per configurare Entity Framework e i servizi:
```c#
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
```



# Esempio pratico

Contatto

richiesta:

```bash
POST /api/contatto/5/
```

## Flusso generico delle informazioni:

- Controller riceve richiesta

- Controller chiama ContattoService

- ContattoService chiama ContattoRepository

- ContattoRepository legge il Db e restituisce dati

- I dati vengono ritornati al Model e poi al Controller

- Controller restituisce risposta HTTP al client Angular passando attraverso un DTO (per non esporre direttamente il Model)

- Viene generata response in JSON a Angular



# WEBAPI RUBRICA COMPLETA V1    

La web api app rubrica userà JWT per autenticare i client Angular, e avrà:
## Modelli:
- Un modello Contatto con proprietà come Id, Nome Completo, Telefono, stato attivo, una lista di competenze e data di creazione.

- Un modello User con Id, Username, PasswordHash e Ruolo per gestire l'autenticazione e autorizzazione e il collegamento con i contatti.

- Data annotations e decorators per validazione e sicurezza, ad esempio `[Required], [StringLength]`
---
## DTOs:
- Un DTO ContattoDto con solo alcune proprietà per esporre i dati in modo sicuro, potrebbe esporre solo Id, Nome completo e Telefono

- Un altro DTO UserDto per esporre solo Username e Ruolo senza esporre la password o altri dati sensibili.
---
## Controllers:
- Un controller ContattoController con endpoint CRUD per gestire i contatti

- Un controller UserController per gestire la registrazione e gestione degli utenti

- Un controller AuthController per gestire l'autenticazione e la generazione di token JWT
---
## Services:
- Un servizio ContattoService che contiene la logica di business per i contatti

- Un servizio UserService per la logica di gestione degli utenti e delle credenziali

- Un servizio AuthService per la logica di autenticazione e gestione dei token JWT
---
## Repositories:
- Un repository ContattoRepository che interagisce con il database usando Entity Framework Core

- Un repository UserRepository per gestire gli utenti e le credenziali di autenticazione

- Un repository AuthRepository per gestire la logica di autenticazione e validazione delle credenziali
---
## Data:
- Un DbContext ApplicationDbContext che rappresenta il database e contiene un `DbSet<Contatto>` e un `DbSet<User>`

- Middleware per gestire l'autenticazione JWT e proteggere gli endpoint

- Configurazione in Program.cs per registrare i servizi, configurare Entity Framework e abilitare l'autenticazione JWT.

---
## Middleware

- Un middleware JwtMiddleware per intercettare le richieste e validare i token JWT, assicurando che solo utenti autenticati possano accedere agli endpoint protetti.

- Un middleware di gestione degli errori per catturare eccezioni globali e restituire risposte HTTP appropriate in caso di errori.
---
## Helpers:
- Un Helper JwtHelper per generare e validare i token JWT

- Un helper PasswordHelper per gestire l'hashing e la verifica delle password

---
## Configurazione in Program.cs

- La configurazione del Db con Entity Framework ed i JWT 
---
## Migrations:
- Migrazioni per creare le tabelle Contatti e Users nel database usando Entity Framework Core






# CREAZIONE PROGETTO E COMANDI
Creazione archetipo webapi
```bash
dotnet new webapi -o "Rubrica.Api"
```

Installazione librerie:

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
- JWT e autenticazione:
```bash
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package System.IdentityModel.Tokens.Jwt
dotnet add package Microsoft.IdentityModel.Tokens
```
VERIFICARE INSTALLAZIONI SU FILE .CSPROJ



# Passaggi per l'installazione di Variabili di ambiente:
- Sito SQLite (o almeno in questo caso)
- Sezione Download
- Scaricare sqlite-dll-win-x64-3520000.zip
- Estrarre il file .dll
- Cercare "variabili" nella ricerca Windows
- Aprire il programma ed andare su "Variabili d'ambiente..."
- Andare sotto "Variabili di Sistema" ed aprire "Path"
- Spostare il file .dll in una cartella in Programs denominata Sqlite
- Vedere il percorso del file .dll appena spostato tramite le Proprietà
- Copiare il percorso nella sezione PAth aggiungendo una nuova riga es:`C:\Program Files\Sqlite
- Riavviare il PC



## IMPORTANTE
Per usare Sqlite bisogna installare la .dll dal sito SQLite e completare la procedura di aggiunta precedentemente scritta.

# Creazione DbContext
Il DbContext è la classe principale di Entity Framework che gestisce la connessione al database e le operazioni CRUD che vengono eseguite sulle entità dei services dell'applicazione.

Creazione DbContext:
- File ApplicationDbContext.cs in /Data:
```c#
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    //Costruttore che accetta le opzioni di configurazione del dbcontext
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        //qui non serve aggiungere niente, il costruttore base si occupa di configurare il dbcontext con le opzioni fornite in Programs
    }

    //DbSet per la tabella contatti
    public DbSet<Contatto> Contatti { get; set; }
    //DbSet per la tabella Users
    public DbSet<User> Users { get; set; }
}
```

# Creazione Modelli:
I modelli rappresentano le entità del dominio e sono mappati a tabelle del database. In questo caso, abbiamo un modello Contatto e un modello User.

-File Contatto.cs in \Models: (con aggiunta di decorators)
```c#
using System.ComponentModel.DataAnnotations;

namespace Rubrica.Api.Models;

public class Contatto
{
    //chiave primaria della tabella
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public string NomeCompleto { get; set; } = string.Empty;
    
    [Required]
    [StringLength(30)]
    public string Telefono { get; set; } = string.Empty;
    
    //lista delle comptenze del contatto
    //in SQLite la salveremo come testo JSON nel DbContext
    public List<string> Competenze { get; set; } = new();

    public bool IsActive { get; set; } = true;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; //orario attuale col fuso orario londinese

    //Foreign key: ogni contatto appartiene a un utente
    public int UserId { get; set; }

    //proprità di navigazione: EF Core usa questa proprità
    //per collegare il contatto al suo utente
    public User User { get; set; } = null!; //ti serve l'oggetto User per arrivare allo User ID
}
```

- File User.cs in \Models:
```c#
using System.ComponentModel.DataAnnotations;

namespace Rubrica.Api.Models;

public class User
{
    //chiave primaria
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public string Username { get; set; } = string.Empty;
    
    //qui NON salviamo la password in chiaro
    //salviamo solo l'hash creato dal PasswordHasher
    [Required]
    public string PasswordHash { get; set; } = string.Empty;
    
    [Required]
    [StringLength(20)]
    public string Ruolo { get; set; } = "User";

    //un utente può avere molti contatti
    public List<Contatto> Contatti { get; set; } = new();
}
```

# Creazione DTOs:

I DTOs (Data Transfer Objects) servono per non esporre direttamente i Models e per controllare quali dati vengono trasferiti tra client e server. (è quello che vede la pagina)

## DTOs:
- ContattoDto (contiene solo le proprietà che vogliamo esporre al frontend)
- UserDto (contiene solo username e ruolo senza esporre le password)
`IMPORTANTE: Gli altri DTO che servono dobbiamo ancora farli e saranno:`
- ContattoCreateDto.cs (le competenze possono essere vuote ma non null)
- ContattoUpdateDto.cs
- RegisterUserDto.cs (se non passiamo il ruolo diventa User di default)
- LoginDto.cs
- AuthResponseDto.cs (DTO che torniamo al frontend dopo il login)

- File ContattoDto.cs in \Dtos:
```c#


namespace Rubrica.Api.Dtos;

public class ContattoDto
{
    //DTO di risposta: è quello che rimandiamo al frontend
    public int Id { get; set; }
    public string NomeCompleto { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public List<string> Competenze { get; set; } = new(); 
    public bool IsActive { get; set; } 
    public DateTime CreatedAt { get; set; }
}
```

- File UserDto.cs in \Dtos:
```c#
namespace Rubrica.Api.Dtos;
public class UserDto
{
    //DTO sicuro di risposta: non contiene PasswrodHash(?)
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Ruolo { get; set; } = string.Empty;
}
```

# Configurazione in Program.cs
Il program.cs è il punto d'ingresso dell'applicazione, dove viene configurato il pipeline d'esecuzione e i servizi. Qui configuriamo Entity Framework, JWT e registriamo i servizi e repository.

OPZIONALE: possiamo configurare un seed (meglio se su un file separato dove viene preso l'admin di default e 3 utenti uno per ogni ruolo)

- File Program.cs (Main?):
```c#
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNeyCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Rubrica.Api.Data;
using Rubrica.APi.Dtos;
using Rubrica.Api.Helpers;
using Rubrica.Api.Middleware;
using Rubrica.Api.Models;
using Rubrica.Api.Repositories;
using Rubrica.Api.Services;


var builder = WebApplication.CreateBuilder(args);//

//aggiunge i controller
builder.Services.AddControllers();

//configura il DbContext con Sqlite
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

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

//leggiamo la chiave JWT da appsettings
var jwtKey = builder.Configuration["Jwt:Key"]
             ?? throw new Exception("Jwt:Key mancante in appsettings.json"); //questo serve

//Configurazione autenticazione JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            //Controlla che il token sia stato emesso dall'issuer corretto
            ValidateIssuer = true,

            //Controlla che il token sia destinato all'audience corretta
            ValidateAudience = true,

            //Controlla che il token non sia scaduto
            ValidateLifetime = true,

            //Controlla la firma del token
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });
```