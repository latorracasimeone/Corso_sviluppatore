# Come fare
Se dopo aver tentato non parte, per esempio, la migrazione con 
```bash
dotnet ef migrations add Prove
```
seguire i seguenti passaggi:
## 1. Cancella le cartelle temporanee
Ovvero `bin` e `obj`
2. (Passaggio opzionale) Controllare la cartella wwwroot, se presente.
## 3. Ricostruisci da zero:
Nel terminale:
```bash
dotnet restore
```
e subito dopo:
```bash
dotnet build
```
per visualizzare eventuali errori.
# Riprova migrazioni
Alcune volte, dopo la migrations, anche se effettuata con successo, potrebbe darti un fastidiosoc warning facilmente risolvibile con
```bash
dotnet add package SQLitePCLRaw.bundle_e_sqlite3
```