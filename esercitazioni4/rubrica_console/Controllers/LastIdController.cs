using Newtonsoft.Json;
public class LastIdController
{
    private readonly string path = "lastId.json";
    private LastId lastIdObj;

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