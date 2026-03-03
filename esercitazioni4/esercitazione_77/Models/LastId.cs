
lastId.Id = -1; //questo è un valore non valido
//context
var context = new ValidationContext(LastId);
try
{
    //validate object restituisce un'eccezione se l'oggetto non è valido, altrimenti non restituisce nulla
    Validator.ValidateObject(LastId, context, true);
}
catch (ValidationException ex)
{
    Console.WriteLine(ex.Message);
}