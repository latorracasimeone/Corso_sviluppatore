using Newtonsoft.Json;
public class LastIdController
{
    private readonly string path = "lastId.json";
    private LastId lastIdObj;

    public LastIdController()
    {
        lastIdObj = JsonHelper.Leggi<LastId>(path) ?? new LastId { Id = 0 };
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