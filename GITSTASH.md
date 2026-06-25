#  GIT: GESTIONE DELLO STASH (Il cassetto)
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

# ESEMPIO PRATICO SU WEBAPI CONDIVISA

Ho capito esattamente il tuo problema. La buona notizia è che il git stash funziona benissimo e non sta sbagliando nulla. Il problema non è nel cassetto, ma in un concetto fondamentale di Git: l'isolamento dei Branch.

Perché non vedi le modifiche scaricate?

Immagina i branch come due binari ferroviari paralleli.

Tu sei sul binario angular/gestione.

Fai git stash -u (metti in valigia il tuo lavoro).

Salti sul binario developer.

Lì fai git pull e scarichi il codice nuovo dei tuoi colleghi. Ora il binario developer è andato avanti di 10 km.

Salti di nuovo sul tuo binario angular/gestione.

Tiri fuori la valigia (git stash apply).

L'intoppo è qui: il tuo binario angular/gestione è rimasto indietro di 10 km! Aggiornare developer aggiorna solo ed esclusivamente developer. Il tuo branch personale non assorbe magicamente le modifiche dell'altro branch solo perché hai cambiato schermata.

La tua soluzione funziona?
Quella che proponi (lavorare direttamente su developer, stashare, aggiornare e poi creare il branch) tecnicamente funziona, ma è considerata una pratica rischiosa. Lavorare direttamente sul developer è come camminare su un campo minato: se per sbaglio fai un commit lì, "sporchi" il ramo principale condiviso con tutti.

La Soluzione Definitiva (Il workflow professionale)
C'è un passaggio chiave che ti manca: devi dire esplicitamente a Git di prendere le novità di developer e iniettarle nel tuo branch. Lo si fa con il comando merge.

Ecco i passi esatti che devi fare la prossima volta per sincronizzarti senza perdere nulla:
```git bash
# 1. Salva il tuo lavoro in corso
git stash -u

# 2. Vai su developer e scarica le novità di tutti
git checkout developer
git pull --ff-only

# 3. Torna sul TUO branch
git checkout angular/gestione

# 4. IL PASSAGGIO MAGICO: Inietta le novità di developer nel tuo branch!
git merge developer

# 5. Ora tira fuori il tuo lavoro dal cassetto
git stash pop
//oppure
git stash apply



# 6. (opzionale) ricorda di tanto in tanto di fare uno dei seguenti comandi

# Elimina l'ultimo salvataggio (stash@{0})
git stash drop

# Oppure, se vuoi svuotare completamente tutto il cassetto dai vecchi salvataggi accumulati: 
git stash clear
```