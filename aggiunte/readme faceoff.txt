# FaceOff


## Idea 

un applicazione di organizzazione di incontri di boxe


## Ruoli

- Combattenti: Sola lettura (vedono il loro storico).

- Allenatori/Manager: Funzioni di scrittura (iscrivono i combattenti all'evento).

- Arbitri (o Giudici): (Nella boxe l'arbitro sta sul ring, i giudici danno i punti. Per semplicità nel vostro database chiamatelo pure Arbitro o UfficialeDiGara). Loro avranno il permesso (tramite la vostra Web API) di fare l'UPDATE del campo esito nella tabella Match.

- Ha contatto diretto con gli allenatori delle palestra che vogliono fare parte del progetto con i propri combattenti.
