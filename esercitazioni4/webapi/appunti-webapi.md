#WEB API
L'archetipo web api è un progetto ASP.NET Core che espone endpoint HTTP per consentire a client frontend come Angular di interagire con i dati prodotti dal backend.

Il comando per creare un'applicazione web API è:

```bash
dotnet new webapi -o "Rubrica.Api"
```
(o senza virgolette nel caso non ci fossero spazi vuoti, il .Api per differenziarlo dagli altri tipi di file simili, rubriche in questo caso.)

##Struttura tipica di una web API

```bash
Rubrica.Api
├ Controllers
├ Models
├ Services
├ Data
├ Dtos
├ Migrations
├ Middleware
├ Helpers
├ Program.cs
├ appsettings.json
├ Properties
│  └ launchSettings.json

##Cartelle principali:
- Controllers: Contiene i controller che gestiscono le richieste HTTP e restituiscono risposte.
- Models: Contiene le classi che rappresentano i dati e le entità del Dominio.

- Services: Contiene la logica di business e i servizi che interagiscono con i dati, cioè le operazioni CRUD e altre logiche complesse.

`CRUD sono i metodi di creazione, lettura, modifica ed eliminazione`

-Data: Contiene il contesto del database (il contesto del database contiene i percorsi per pescare i driver, NOI utilizziamo driver sqlight) e le classi di accesso dati.
-Dtos: Contiene le classi Data Transfer Object, che sono altri modelli specifici per il trasferimento dei dati tra client e server, spesso usati per evitare di esporre direttamente le entità del dominio. (cosa significherebbe esporre tutti i modelli???????)

-Migrations: Contiene le migrazioni di Entity Framework (?) per gestire le modifiche al database quando viene modificato un modello.
- Middleware: Contiene componenti middleware personalizzati per gestire richieste e risposte HTTP, ad esempio per la gestione degli errori o l'autenticazione.
-Helpers: Contiene classi di utilità e helper per operazioni comni, come la gestione dei file, la validazione personalizzata, ecc ecc.

-Properties: Contiene file di configurazione specifici del progetto, come LaunchSettings.json che definisce le configurazioni di avvio per l'applicazione.

-Program.cs: il punto d'ingresso dell'applicazione, dove viene configurato il pipeline (fatto a step, comandi in sequenza?) di esecuzione e i servizi.

-appsettings.json: il file di configurazione principale dell'applicazione, dove vengono definiti parametri come stringhe di connessione al database, chiavi API e altre impostazioni.