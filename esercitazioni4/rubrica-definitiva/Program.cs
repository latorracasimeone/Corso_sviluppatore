
/// -utilizzo di classi modello per rappresentare i dati dei contatti e degli ID




/// -utilizzo di classi controller per gestire la logica di business della rubrica



/// -suddivisione dei files in folders di Models, Controllers, Helpers e Data (e invece Services/?????????????)
/// -utilizzo di una classe statica JSONHelper per semplificare la lettura e scrittura dei file Json


class Program //questo serve per gestire l'interazione con l'utente, chiedendo i comandi e i dati necessari per eseguire le operazioni sulla rubrica, e chiamando i metodi appropriati del RubricaController e del LastIdController in base ai comandi inseriti dall'utente. Il ciclo continua fino a quando l'utente non inserisce il comando "exit" per terminare il programma.
{
    static void Main(string[] args) //questo è il modo FISSO di creare il Main.
    {
        RubricaController rubricaController = new RubricaController();
        LastIdController lastIdController = new LastIdController();

        while (true)
        {
            Console.WriteLine("Inserisci uno dei seguenti comandi: \n'stamp' per stampare la rubrica, \n'agg' per aggiungere un contatto, \n'canc' per eliminare un contatto, \n'mod' per modificare un contatto, \n'exit' per uscire:");
            string nome = Console.ReadLine();

            if (nome.ToLower() == "exit")
            {
                rubricaController.StampaRubrica();
                break;
            }
            else if (nome.ToLower() == "canc")
            {
                rubricaController.StampaRubrica();
                Console.WriteLine("Inserisci l'ID del contatto da eliminare:");
                if (int.TryParse(Console.ReadLine(), out int idDaEliminare))
                {
                    rubricaController.EliminaContatto(idDaEliminare);
                }
                else
                {
                    Console.WriteLine("ERRORE: ID non valido.");
                }
                continue; // Torna all'inizio del ciclo per chiedere un nuovo comando
            }
            else if (nome.ToLower() == "mod")
            {
                rubricaController.StampaRubrica();
                Console.WriteLine("Inserisci l'ID del contatto da modificare:");
                if (int.TryParse(Console.ReadLine(), out int idDaModificare))
                {
                    Console.WriteLine("Inserisci il nuovo nome:");
                    string nuovoNome = Console.ReadLine();
                    Console.WriteLine("Inserisci il nuovo numero di telefono:");
                    string nuovoNumero = Console.ReadLine();
                    rubricaController.ModificaContatto(idDaModificare, nuovoNome, nuovoNumero);
                }
                else
                {
                    Console.WriteLine("ERRORE: ID non valido.");
                }
                continue; // Torna all'inizio del ciclo per chiedere un nuovo comando
            }
            else if (nome.ToLower() == "stamp")
            {
                rubricaController.StampaRubrica();
                continue; // Torna all'inizio del ciclo per chiedere un nuovo comando
            }
            else if (nome.ToLower() == "agg")
            {
                while (true)
                {
                    Console.WriteLine("Inserisci il nome del contatto da aggiungere:");
                    string nomeDaAggiungere = Console.ReadLine();
                    Console.WriteLine("Inserisci il numero di telefono:");
                    string numero = Console.ReadLine();
                    rubricaController.AggiungiContatto(nomeDaAggiungere, numero);
                    Console.WriteLine("Contatto aggiunto. Vuoi aggiungere un altro contatto? (n per uscire)");
                    if (Console.ReadLine().ToLower() == "n") //ToLower perché vogliamo accettare sia "n" che "N" come risposta per uscire dal ciclo di aggiunta dei contatti
                    {
                        break; // Esce dal ciclo di aggiunta dei contatti e torna all'inizio del ciclo principale per chiedere un nuovo comando
                    }
                }
            }
            else
            {
                Console.WriteLine("Comando non riconosciuto. Riprova.");
            }
        }
    }
}
/// -validazione dei dati di input tramite decoratori
/// Il focus di questo programma è sull'organizzazione del codice e sull'utilizzo dei decoratori per validare i dati di input
/// La suddivisione completa delle responsabilità delleclassi modello, controller e helper permette di mantenere il codice pulito, modulare e facilmente manutentibile