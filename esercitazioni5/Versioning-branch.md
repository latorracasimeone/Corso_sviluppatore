# Versioning branch

## Mini glossario dei comandi usati
- `git switch <branch>` : passa a un branch
- `git switch -c <branch>` : crea e passa al nuovo branch
- `git pull --ff-only` : aggiorna il branch solo se può "avanzare dritto" (evita merge automatici)
- `git fetch (--all)` : scarica aggiornamenti dal remoto senza toccare i file locali
- `git add <file>` : prepara i file per il commit
- `git commit -m "messaggio"` : registra le modifiche con un messaggio breve e chiaro
- `git push -u origin <branch>` : pubblica il branch e imposta il tracciamento con origin
- `git branch -m <nuovo-nome>` : rinomina un branch locale
- `git push origin :<branch>` : elimina un branch sul remoto
- `git branch -d <branch>` : elimina un branch locale già mergiato (sicuro)
- `git revert <SHA>` : annulla un commit già pubblicato creando un commit inverso
- `git merge origin/<branch>` : unisce nel tuo branch le ultime modifiche del branch remoto
- `git tag -a vX.Y.Z -m "note"` : crea un tag "di versione" con descrizione
- `git branch -a` : ti fa visualizzare i branch in locale in verde e in remoto in rosso

## Regole semplici per non pestarsi i piedi
- Solo una persona crea il repository e i branch prinicpali (main, developer).
- La persona che crea il repository (es. lead) è autorizzata a fare i merge.
- Gli altri sivluppatori quando hanno fatto la modifica o il fix aprono una PR verso developer (Pull Request)
- Ogni Task o modifica o fix deve essere più semplice possibile, cioè se è troppo complessa dev'essere separata in più task semplici (come ragioniamo con le funzioni, non ha senso una singola funzione che faccia 3 cose, molto meglio 3 funzioni ognuna dedicata solo ed esclusivamente a fare una cosa, per ordine e pulizia).
- Bisogna necesariamente far procedere il lavoro e di conseguenza fare il merge di piccoli task semplici, invece di aspettare di avere il task complesso completo per fare un unico merge (es: non una volta a settimana, ma magri quotidianamente).
- Bisogna necessariamente rispettare le convenzioni per i nomi dei branch ma anche per le variabili del codice, per i messaggi dei commit, per i nomi dei file, ecc.
- Il branch main è solo per il codice stabile e rilasciato, non ci si lavora direttamente.
- Solo una persona del team (es. lead) fa merge su main, dopo aver testato e verificato che è tutto ok. 
- Creare sempre un branch developer per integrare le modifiche prima di portarle sul main.
- Non bisogna mai lavorare sul developer o sul main, ma bisogna lavorare solamente su feature branch.
- Prima di creare una feature: `git switch developer && git pull --ff-only`.
- Una feature = un branch = una PR (Pull Request) verso developer.
- Evita di modificare le stesse righe: se serve, parlatevi prima.
- Risolvi i conflitti in locale, poi aggiorna la PR.
- Niente push forzati su developer o main.
- Elimina i branch feature dopo il marge (locale e remoto).

PROVARE TRELLO