# 1. TERMINOLOGIA C# (Web API)
## I concetti base per leggere e scrivere un backend.

- Modello (Model): La struttura dei dati (es. classe Utente). Non ha logica, ha solo proprietà. Spesso si trova nella cartella Models.

- Istanza: L'oggetto fisico creato in memoria partendo dal Modello (la "casa" costruita dalla "planimetria").

- Metodo: L'azione o la funzione (es. SalvaDati()).

- Argomento: Il valore reale che inserisci nelle parentesi del metodo quando lo chiami.

- Flag: Una variabile booleana (true o false) usata come interruttore o per verificare uno stato.

```c#
// Modello: la classe UtenteModel
// Istanza: la variabile 'nuovoUtente' (creata col 'new')
UtenteModel nuovoUtente = new UtenteModel();

// Flag: la variabile 'isBannato'
bool isBannato = false; 

// Metodo: 'SalvaUtente'
// Argomento: 'nuovoUtente' (passato tra le parentesi)
_service.SalvaUtente(nuovoUtente);
```

# 2. METODO "A CASCATA" (Fluent Interface / Method Chaining)
Un modo per scrivere codice in modo compatto, chiamando più metodi di seguito sulla stessa riga (o andando a capo col punto).
Requisito: I metodi della classe devono terminare con return this; (restituire l'istanza stessa).

```c#
// Esempio di configurazione a cascata (Molto usato in Program.cs o Entity Framework)
var nuovoUtente = new UtenteModel()
    .ImpostaNome("Mario")
    .ImpostaCognome("Rossi")
    .SetAttivo(true);
```

# 3. TUPLE vs CLASSI (Restituire due valori in C#)
Nelle Web API, i Service spesso devono restituire due cose: i dati veri e propri E un eventuale messaggio di errore.

## Uso della Tupla (Il metodo rapido)
Spacchetta due o più valori direttamente in variabili separate.

```c#
// La sintassi var (a, b) apre il pacchetto restituito dal service
var (risultato, errore) = await _bigliettoService.CreazioneAsync(dto, utenteId);
```

## Alternativa alla Tupla: Creare una Classe (Result Pattern)
Se non si vogliono usare le tuple, bisogna creare un Modello/Classe apposita che contenga le due proprietà.

```c#
// Creazione di una classe apposita per la risposta
public class RispostaCreazione {
    public DtoBiglietto Dati { get; set; }
    public string Errore { get; set; }
}

// Nel controller, estrai le proprietà col punto:
var risposta = await _bigliettoService.CreazioneAsync(dto, utenteId);
if (risposta.Errore != null) { return BadRequest(risposta.Errore); }
```

# 4. LINQ: ALTERNATIVE A FOR / FOREACH IN C#
LINQ permette di manipolare liste di dati scrivendo meno codice (stile dichiarativo). Attenzione: Usa il foreach classico se devi fare operazioni asincrone (await) dentro il ciclo.

- Trasformare (creare una nuova lista prendendo un solo dato):

```c#
var listaNomi = utenti.Select(u => u.Nome).ToList();
```

- Filtrare (prendere solo chi rispetta una condizione):

```c#
var minorenni = utenti.Where(u => u.Eta < 18).ToList();
```

- Verificare (restituisce un booleano / flag):

```c#
bool esisteUnAdmin = utenti.Any(u => u.Ruolo == "Admin");
bool tuttiAttivi = utenti.All(u => u.IsAttivo == true);
```

Eseguire un'azione rapida su tutti (senza await):

```c#
utenti.ForEach(u => Console.WriteLine(u.Nome));
```

# 5. GIT: GESTIONE DELLO STASH (Il cassetto)
Serve per mettere via temporaneamente codice non salvato per poter cambiare branch senza fare commit sporchi.

## Salva le modifiche dei file tracciati nel cassetto e pulisce il branch:

```git bash
git stash
// o versione estesa:
git stash push
```

## Salva nel cassetto TUTTO, compresi i file appena creati (Untracked):
 
```git bash
git stash -u
// o versione estesa:
git stash push -u
```

## Mostra l'elenco dei salvataggi nel cassetto:
 
```git bash
git stash list
```

## Applica l'ultimo salvataggio al codice attuale ED ELIMINA lo stash dal cassetto:
 
```git bash
git stash pop
```

## Applica l'ultimo salvataggio al codice attuale ma LO MANTIENE nel cassetto:
 
```git bash
git stash apply
```

# 6. GIT: UPSTREAM E ORIGIN
- Origin: Il nome di default del tuo repository remoto su internet (es. su GitHub).

- Upstream: La "sorgente a monte". Serve a dire al tuo branch locale con quale branch remoto deve parlare.

## Collega un nuovo branch locale al remoto durante il primo push (flag -u):
 
```git bash
git push -u origin nome-del-mio-branch
/// SEMPRE USATO!!!!!
```

# 7. GIT: VARIANTI DI "ADD" (La Staging Area)
Decide cosa preparare per il prossimo commit.

- Aggiunge TUTTI i file (nuovi, modificati, eliminati) dalla cartella attuale in giù:
 
```git bash
git add.
```

- Aggiunge SOLO i file già tracciati che sono stati modificati o cancellati (Ignora i file nuovi):
 
```git bash
git add -u
```

- Aggiunge TUTTO l'intero progetto, a prescindere da quale cartella ti trovi nel terminale:
 
```git bash
git add -A
// OPPURE CIò CHE USIAMO DI SOLITO, la versione "lunga"
git add --all
```

- Aggiunge file in modo selettivo (riga per riga), chiedendoti conferma (Patch mode, solo per determinate situazioni Pro):
 
```git bash
git add -p
```

# 8. PILLOLE DI FRONTEND
Concetti base per interfacce web.

## Angular
- È un Framework, non un linguaggio (è l'equivalente di ASP.NET Core per il frontend).

- Serve per creare SPA (Single Page Application).

- Lavora a Componenti formati da: HTML (struttura/scheletro), CSS (stile/colori) e TypeScript (logica/cervello).

## CSS: Flexbox vs Grid
- Flexbox: Impagina in 1 Dimensione alla volta (solo riga o solo colonna). Perfetto per allineare elementi dentro un contenitore (es. bottoni in una navbar).

- Grid: Impagina in 2 Dimensioni insieme (righe + colonne). Perfetto per creare lo scheletro principale della pagina (Header, Sidebar, Main, Footer).

## Console Log (JavaScript / TypeScript)
Il comando fondamentale per fare debug sul frontend. Stampa dati dietro le quinte. Si legge premendo F12 sul browser (scheda "Console").
 
```TypeScript
// Esempio TS/JS: Stampa i dati arrivati dall'API per controllare che ci siano
console.log("I dati caricati sono:", biglietti);
```
 