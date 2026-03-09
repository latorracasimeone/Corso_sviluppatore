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

