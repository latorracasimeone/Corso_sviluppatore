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