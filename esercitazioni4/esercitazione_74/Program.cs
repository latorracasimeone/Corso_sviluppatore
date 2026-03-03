//LEZIONE 18 CLASSI STATICHE
//Non possono essere istanziate

using Newtonsoft.Json;

// devo creare un'istanza della classe LastIdController per poter utilizzare il metodo GetNextId, che è un metodo di istanza
var lastIdController = new LastIdController();
int nextId = lastIdController.GetNextId();
Console.WriteLine($"Il prossimo ID è: {nextId}");


public class LastId 
{
    public int Id { get; set; }
}





//esempio
public static class JsonHelper 
{
    public static void Salva(string path, object obj)
    {
        string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
        File.WriteAllText(path, json);
    }
    public static T Leggi<T>(string path)
    {
        if (File.Exists(path))
        {
            return default(T);
        }
        string json = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<T>(json);
    }
}

public class LastIdController 
{
    private readonly string path = "lastId.Json";
    private LastId lastIdObj;
    public LastIdController()
    {
        lastIdObj = JsonHelper.Leggi<LastId>(path) ?? new LastId ( Id = 0 );
    }
    public int GetNextId()
    {
        lastIdObj.Id++;
        JsonHelper.Salva(path, lastIdObj);
        return lastIdObj.Id;
    }
}

