# CHOCOLATEY
- Da scaricare dal sito sotto products, poi pricying, open source, individual e copia il comando dentro al powershell.
 
`Se questo non dovesse andare riprovare dopo aver aperto C:/ProgramData e cancellato la cartella chocolatey.` 
- Dopodiché, aprire Visual Studio Code come amministratore
- Verifica nel terminal powershell scrivendo "choco" l'avvenuta installazione. 
- Subito dopo "choco install jq" su powershell, poi ulteriore verifica con "jq --version".
- Ulteriore verifica con 
```bash
echo '{"token":"abc"}' | jq -r '.token'
```
## Tornando sul file WEBAPI (Rubrica.Api in questo caso)
Copiare questo, dopo aver fatto dotnet run
```bash
TOKEN=$(curl -s -X POST "http://localhost:5062/api/Auth/login" \
  -H "Content-Type: application/json" \
  -d '{"email":"utente1@email.com","password":"123456"}' | jq -r '.token')
```