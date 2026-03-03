//LEZIONE 17 CLASSI CONTATTO
using Newtonsoft.Json;


// devo creare un'istanza della classe LastIdController per poter utilizzare il metodo GetNextId, che è un metodo di istanza
var lastIdController = new LastIdController();
int nextId = lastIdController.GetNextId();
Console.WriteLine($"Il prossimo ID è: {nextId}");


// indico public per rendere la classe accessibile da altre parti del programma
public class LastIdController
{
    // private per il percorso in modo che non sia accessibile da altre parti del programma
    // readonly per indicare che il valore non può essere modificato dopo l'inizializzazione
    private readonly string path = "lastId.json";
    // private per l'oggetto lastIdObj in modo che non sia accessibile da altre parti del programma
    private LastId lastIdObj;

    // questo è il costruttore della classe LastIdController, che viene chiamato quando viene creata un'istanza della classe
    // viene definito pubblico per permettere la creazione di istanze della classe da altre parti del programma
    public LastIdController()
    {
        if (!File.Exists(path))
        {
            lastIdObj = new LastId { Id = 0 };
            Salva();
        }
        else
        {
            string json = File.ReadAllText(path);
            // ?? è un operatore di coalescenza nulla
            // restituisce il valore a sinistra se non è null, altrimenti restituisce il valore a destra
            lastIdObj = JsonConvert.DeserializeObject<LastId>(json) ?? new LastId { Id = 0 };
        }
    }

    public int GetNextId()
    {
        lastIdObj.Id++;
        Salva();
        return lastIdObj.Id;
    }

    private void Salva()
    {
        string json = JsonConvert.SerializeObject(lastIdObj, Formatting.Indented);
        File.WriteAllText(path, json);
    }
}

public class LastId
{
    public int Id { get; set; }
}













public class ContattiController
{
    // queste sono le variabili di istanza della classe ContattiController
    // cioè le variabili che appartengono a ogni istanza della classe
    // e possono essere utilizzate in tutti i metodi della classe
    private readonly string path = "contatti.json";
    private List<Contatto> contatti;
    private LastIdController lastIdController;

    public ContattiController()
    {
        // creo un'istanza della classe LastIdController per poter utilizzare i metodi di quella classe
        // in particolare GetNextId per generare nuovi ID per i contatti
        lastIdController = new LastIdController();
        if (!File.Exists(path))
        {
            // se il file non esiste, creo una lista vuota di contatti e la salvo su file
            contatti = new List<Contatto>();
            Salva();
        }
        else
        {
            string json = File.ReadAllText(path);
            // deserializzo il file JSON in una lista di contatti, se il file è vuoto o non contiene dati validi, creo una lista vuota
            // con l'operatore di coalescenza nulla che restituisce la lista deserializzata se non è null
            // altrimenti restituisce una nuova lista vuota
            contatti = JsonConvert.DeserializeObject<List<Contatto>>(json) ?? new List<Contatto>();
        }
    }

    public List<Contatto> GetContatti()
    {
        return contatti;
    }

    private void Salva()
    {
        string json = JsonConvert.SerializeObject(contatti, Formatting.Indented);
        File.WriteAllText(path, json);
    }

    public void AggiungiContatto(string nome, string cognome, string telefono, bool presente, List<string> interessi)
    {
        Contatto nuovoContatto = new Contatto
        {
            Id = lastIdController.GetNextId(),
            Nome = nome,
            Cognome = cognome,
            Telefono = telefono,
            Presente = presente,
            Interessi = interessi
        };
        contatti.Add(nuovoContatto);
        Salva();
    }

    public void ModificaContatto(int id, string nome, string cognome, string telefono, bool presente, List<string> interessi)
    {
        Contatto contattoEsistente = null;
        foreach (var contatto in contatti)
        {
            if (contatto.Id == id)
            {
                contattoEsistente = contatto;
                break;
            }
        }
        if (contattoEsistente != null)
        {
            contattoEsistente.Nome = nome;
            contattoEsistente.Cognome = cognome;
            contattoEsistente.Telefono = telefono;
            contattoEsistente.Presente = presente;
            contattoEsistente.Interessi = interessi;
            Salva();
        }
    }

    public void EliminaContatto(int id)
    {
        Contatto contattoEsistente = null;
        foreach (var contatto in contatti)
        {
            if (contatto.Id == id)
            {
                contattoEsistente = contatto;
                break;
            }
        }
        if (contattoEsistente != null)
        {
            contatti.Remove(contattoEsistente);
            Salva();
        }
    }

    public Contatto VisualizzaContatto(int id)
    {
        Contatto? contattoEsistente = null;
        foreach (var contatto in contatti)
        {
            if (contatto.Id == id)
            {
                contattoEsistente = contatto;
                break;
            }
        }
        if (contattoEsistente == null)
        {
            throw new Exception($"Contatto con ID {id} non trovato.");
        }
        return contattoEsistente;
    }
}




public class Contatto
{
    public int Id { get; set; }
    public string Nome { get; set; } = "";
    public string Cognome { get; set; } = "";
    public string Telefono { get; set; } = "";
    public bool Presente { get; set; }
    // proprieta lista di interessi
    public List<string> Interessi { get; set; } = new();
}

