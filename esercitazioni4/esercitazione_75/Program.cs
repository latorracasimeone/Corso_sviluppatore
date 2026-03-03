using Newtonsoft.Json;

// devo creare un'istanza della classe LastIdController per poter utilizzare il metodo GetNextId, che è un metodo di istanza
var lastIdController = new LastIdController();
int nextId = lastIdController.GetNextId();
Console.WriteLine($"Il nuovo ID è: {nextId}");


public class LastId 
{
    public int Id { get; set; }
}

public static class JsonHelper 
{
    public static void Salva(string path, object obj)
    {
        string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
        File.WriteAllText(path, json);
    }

    public static T Leggi<T>(string path)
    {
        // ATTENZIONE: Qui avevi un errore logico! 
        // Se il file ESISTE, devi leggerlo, non ritornare default.
        if (!File.Exists(path)) 
        {
            return default(T);
        }
        string json = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<T>(json);
    }
}

public class LastIdController 
{
    private readonly string path = "lastId.json";
    private LastId lastIdObj;

    public LastIdController()
    {
        // Sintassi corretta per l'inizializzazione: { Id = 0 }
        lastIdObj = JsonHelper.Leggi<LastId>(path) ?? new LastId { Id = 0 };
    }

    public int GetNextId()
    {
        lastIdObj.Id++;
        JsonHelper.Salva(path, lastIdObj);
        return lastIdObj.Id;
    }
}

