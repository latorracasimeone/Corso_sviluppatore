# CHOCOLATEY e GIT Bash
- Da scaricare dal sito sotto products, poi pricying, open source, individual e copia il comando dentro al powershell.
 
`Se questo non dovesse andare riprovare dopo aver aperto C:/ProgramData e cancellato la cartella chocolatey.` 
- Dopodiché, aprire Visual Studio Code come amministratore
- Verifica nel terminal powershell scrivendo "choco" l'avvenuta installazione. 
- Subito dopo "choco install jq" su powershell, poi ulteriore verifica con "jq --version".
- Ulteriore verifica con 
```bash
echo '{"token":"abc"}' | jq -r '.token'
```
# Tornando sul file WEBAPI (Rubrica.Api in questo caso) e generare TOKEN SU GIT BASH
## Copiare questo su GIT Bash, dopo aver fatto dotnet run in PowerShell per Login e Salvataggio del token 
`SARà UGUALE LOCAL HOST SU ENTRAMBI I PC????♠`
```bash
TOKEN=$(curl -s -X POST "http://localhost:5062/api/Auth/login" \
  -H "Content-Type: application/json" \
  -d '{"email":"utente1@email.com","password":"123456"}' | jq -r '.token')
```
5062 perché è quello che mi appare una volta eseguito in powershell il webapi
Gli attributi:
- -H indica che stiamo inviando i dati in formato JSON
- -d contiene i dati, in questo caso l'email e la password dell'utente che vogliamo loggare
## Poi, per verificare se il Token è stato generato, scrivere sempre su git bash 
```bash
$ echo $TOKEN
```
## Leggi interessi dell'utente per la quale è stato creato il token su git bash
```bash
curl -X GET "http://localhost:5062/api/Interests" \
-H "Authorization: Bearer $TOKEN"
```
## Crea Interesse (sempre su git bash e per l'utente per la quale è stato creato il token)
```bash
curl -X POST "http://localhost:5062/api/Interests" \
  -H "Content-Type: application/json" \
  -H "Authorization: Bearer $TOKEN" \
  -d '{"nome":"F1"}'
```
## Modifica interesse 
Dopo Interests/ mettere il numero dell'ID dell'Interesse sulla quale si vuole intervenire
```bash
curl -X PUT "http://localhost:5062/api/Interests/1" \
  -H "Content-Type: application/json" \
  -H "Authorization: Bearer $TOKEN" \
  -d '{"nome":"Formula 1"}'
```
## Cancella interesse
```bash
curl -X DELETE "http://localhost:5062/api/Interests/2" \
-H "Authorization: Bearer $TOKEN" 
```

# Utenti 
`COPIA CODICI CHE HAI CAMBIATO SU AGGIUNTA!!!!!`
## Crea Utente
```bash
curl -X POST "http://localhost:5062/api/Auth/register" \
-H "Content-Type: application/json" \
-d '{"email":"forzaempoli1@email.com","password":"12345678","nomeCompleto":"Arianna","phoneNumber":"+397800","numeroInternazionale":false,"birthday":"1997-05-21"}'
```
c'è il numero internazionale perché abbiamo aggiunto il valore booleano. `A quanto pare, non fa differenza se scrivi numeroInternazionale o NumeroInternazionale. Chiedere come mai.`

## Modifica utente (non implementato, ma si potrebbe fare aggiungendo un endpoint PUT in AuthController).
`interfaccia dell'utente, quindi ovviamente lui può modificare solo se stesso e non gli altri! Stiamo vedendo il tutto dal punto di vista dell'utente, non dello sviluppatore/amministratore!!!!`
```bash
curl -X PUT "http://localhost:5062/api/Auth/update" \
-H "Content-Type: application/json" \
-H "Authorization: Bearer $TOKEN" \
-d '{"nomeCompleto":"Fabio Tammaro Updated", "phoneNumber":"333333333332"}'
```


## Elimina Utente
```bash
curl -X DELETE "http://localhost:5062/api/Auth/delete" \
-H "Authorization: Bearer $TOKEN"
```
## Stampa Utente
```bash
curl -X GET "http://localhost:5062/api/Auth/profile" \
-H "Authorization: Bearer $TOKEN"
```
```bash
//CIO CHE C'è DOPO .../Auth/ DEVE ESSERE CIò CHE NEL CODICE DI AuthController è in [HttpGet("..")], esempio:



.../Auth/profile
[HttpGet("profile")]
```


# MIGRATIONS

La Teoria: Cos'è una Migrazione?
Immagina il database come una casa e le tue classi C# (ApplicationUser) come la planimetria. Se modifichi la planimetria aggiungendo una stanza (NumeroInternazionale), la casa reale non si modifica da sola.
La Migrazione è il "progetto del muratore": un file che dice al database esattamente quali muri spostare o quali colonne aggiungere per allinearsi al codice.

1. Requisiti
Assicurati di avere installato il tool di Entity Framework. Apri il terminale nella cartella del progetto e digita:

```Bash
dotnet tool install --global dotnet-ef
```
2. Creare la Migrazione
Ora devi generare i file che descrivono i cambiamenti. Esegui questo comando:

```Bash
dotnet ef migrations add AggiungiCampiPersonalizzatiUser
```
AggiungiCampiPersonalizzatiUser è solo un nome descrittivo, puoi chiamarlo come vuoi.

EF Core confronterà il tuo ApplicationUser.cs con lo stato precedente e creerà una cartella Migrations nel progetto.

3. Aggiornare il Database
Ora che il "progetto" è pronto, devi applicarlo fisicamente al database:

```Bash
dotnet ef database update
```
Questo comando legge le migrazioni e crea/modifica le tabelle (inclusa la tabella Users con la colonna NumeroInternazionale).


PERCHé APPARE `QUESTO SQLite Error 1: 'table "AspNetUsers" already exists'.` dopo Migrazioni??????????


Migrations funziona anche solo modificando i models, però ovviamente servono i Services e Dtos per gli input e Seeder per gli esempi.

Prima migrare e poi eseguire.