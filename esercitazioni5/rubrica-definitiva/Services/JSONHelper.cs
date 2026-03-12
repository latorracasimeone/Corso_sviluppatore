using Newtonsoft.Json;
public static class JSONHelper
{
    private static string contattiFilePath = "Data/contatti.json"; //questo serve per definire il percorso del file JSON che conterrà i dati dei contatti e del lastId, permettendo di leggere e scrivere i dati in modo semplice e centralizzato
    private static string lastIdFilePath = "Data/lastId.json";

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

    
}