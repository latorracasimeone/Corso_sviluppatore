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
        var context = new ValidationContext(lastIdObj);

        try
        {
            // validate object restituisce un'eccezione se l'oggetto non è valido, altrimenti non restituisce nulla
            Validator.ValidateObject(lastIdObj, context, true);
        }
        catch (ValidationException ex)
        {
            Console.WriteLine(ex.Message);
        }
        JsonHelper.Salva(path, lastIdObj);
        return lastIdObj.Id;
    }
}