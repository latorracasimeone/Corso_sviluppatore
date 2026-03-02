
using Newtonsoft.Json; //necessario per il funzionamento

//LEZIONE 17 CLASSI CONTROLLO

//CORREGGI CON COPILOT E APPRENDI!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

public class LastId
{
    public int Id { get; set; }
}

public class LastIdController
{
    //private per il percorso in modo che non sia accessibile da altri parti del programma
    //readonly per indicare che il valore non può essere modificato dopo l'inizializzazione
    private readonly string path = "lastId.json";
    private LastId LastIdObj;

//questo è il costruttore della classe LastIdController, che viene chiamato quando viene creata un'istanza della classe
//viene definit PUBBLICA PER PERMETTERE LA creazione di istanze della classe da altre parti del programma
public LastIdController()
    {
        if (!File.Exists(path))
        {
            LastIdObj = new LastId { IDictionary = 0 };
            Salva();
        }
        else
        {
            string json = File.ReadAllText(path);
            //?? è un operatore di coolescenza nulla
            //restituisce il valore a sinistra se non è null, altrimenti restituisce il valore a destra
            LastIdObj = JsonConvert.DeserializeObject<LastId>(json) ?? new LastId { Id = 0 };

        }
    }
    public int GetNextId
    {
        LastIdObj.id++;
        Salva();
        return LastIdObj.Id;
    }

    private void Salva()
    {
        string json = JsonConvert.SerializaObject((LastIdObj), Formatting.Indented);
        File.WriteAllText(path, json);
    }
}