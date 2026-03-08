using Newtonsoft.Json;
/// -utilizzo di classi modello per rappresentare i dati dei contatti e degli ID
public class Contatto
{
    public string Nome { get; set; }
    public string Numero { get; set; }
    public int Id { get; set; }
}

public class LastId
{
    public int Id { get; set; }
}

/// -utilizzo di classi controller per gestire la logica di business della rubrica
public class RubricaController
{
    private List<Contatto> rubrica;
    private int lastId;

    public RubricaController() //questo serve per inizializzare la rubrica e il lastId leggendo i dati dai file JSON tramite il JSONHelper
    {
        rubrica = JSONHelper.LeggiContatti();
        lastId = JSONHelper.LeggiLastId();
    }

    public void AggiungiContatto(string nome, string numero) //questo serve per aggiungere un nuovo contatto alla rubrica, incrementando il lastId e salvando i dati aggiornati nei file JSON tramite il JSONHelper. Cosi via dicendo per le altre funzioni di eliminazione, modifica e stampa della rubrica
    {
        Contatto nuovoContatto = new Contatto { Nome = nome, Numero = numero, Id = ++lastId };
        rubrica.Add(nuovoContatto);
        JSONHelper.ScriviContatti(rubrica);
        JSONHelper.ScriviLastId(lastId);
    }

    public void EliminaContatto(int id)
    {
        Contatto contattoDaEliminare = rubrica.FirstOrDefault(c => c.Id == id);
        if (contattoDaEliminare != null)
        {
            rubrica.Remove(contattoDaEliminare);
            JSONHelper.ScriviContatti(rubrica);
        }
        else
        {
            Console.WriteLine($"ERRORE: Contatto con ID '{id}' non trovato.");
        }
    }

    public void ModificaContatto(int id, string nuovoNome, string nuovoNumero)
    {
        Contatto contattoDaModificare = rubrica.FirstOrDefault(c => c.Id == id);
        if (contattoDaModificare != null)
        {
            contattoDaModificare.Nome = nuovoNome;
            contattoDaModificare.Numero = nuovoNumero;
            JSONHelper.ScriviContatti(rubrica);
        }
        else
        {
            Console.WriteLine($"ERRORE: Contatto con ID '{id}' non trovato.");
        }
    }

    public void StampaRubrica()
    {
        Console.WriteLine("Rubrica attuale:");
        foreach (var contatto in rubrica)
        {
            Console.WriteLine($"ID: {contatto.Id}, Nome: {contatto.Nome}, Numero: {contatto.Numero}");
        }
    }
}

public class LastIdController //questo serve per gestire la logica di business relativa al lastId, permettendo di ottenere il prossimo ID disponibile e di salvare l'ultimo ID utilizzato nei file JSON tramite il JSONHelper
{
    private int lastId;

    public LastIdController() //questo serve per inizializzare il lastId leggendo il dato dal file JSON tramite il JSONHelper
    {
        lastId = JSONHelper.LeggiLastId();
    }

    public int GetNextId()
    {
        return ++lastId;
    }

    public void SaveLastId() //questo serve per salvare l'ultimo ID utilizzato nel file JSON tramite il JSONHelper
    {
        JSONHelper.ScriviLastId(lastId);
    }
}
/// -suddivisione dei files in folders di Models, Controllers, Helpers e Data (e invece Services/?????????????)
/// -utilizzo di una classe statica JSONHelper per semplificare la lettura e scrittura dei file Json

public static class JSONHelper
{
    private static string contattiFilePath = "contatti.json"; //questo serve per definire il percorso del file JSON che conterrà i dati dei contatti e del lastId, permettendo di leggere e scrivere i dati in modo semplice e centralizzato
    private static string lastIdFilePath = "lastId.json";

    public static List<Contatto> LeggiContatti() //questo serve per leggere i dati dei contatti dal file JSON, deserializzarli in una lista di oggetti Contatto e restituirli al chiamante. Se il file non esiste, restituisce una lista vuota. Cosi via dicendo per la lettura e scrittura del lastId e per la scrittura dei contatti nel file JSON
    {
        if (File.Exists(contattiFilePath))
        {
            string json = File.ReadAllText(contattiFilePath);
            return JsonConvert.DeserializeObject<List<Contatto>>(json) ?? new List<Contatto>(); //questo serve per gestire il caso in cui il file JSON esista ma sia vuoto, restituendo comunque una lista vuota invece di null
        }
        return new List<Contatto>();
    }

    public static void ScriviContatti(List<Contatto> contatti)
    {
        string json = JsonConvert.SerializeObject(contatti, Formatting.Indented); //questo serve per serializzare la lista di oggetti Contatto in formato JSON e salvarla nel file specificato, sovrascrivendo il contenuto precedente. Il parametro Formatting.Indented serve per rendere il file JSON più leggibile, con una formattazione indentata.
        File.WriteAllText(contattiFilePath, json);
    }

    public static int LeggiLastId()
    {
        if (File.Exists(lastIdFilePath))
        {
            string json = File.ReadAllText(lastIdFilePath);
            return JsonConvert.DeserializeObject<int>(json);
        }
        return 0;
    }

    public static void ScriviLastId(int lastId)
    {
        string json = JsonConvert.SerializeObject(lastId, Formatting.Indented);
        File.WriteAllText(lastIdFilePath, json);
    }
}

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