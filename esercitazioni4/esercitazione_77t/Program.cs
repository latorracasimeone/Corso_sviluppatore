//LEZIONE 20 DECORATORS TEORIA

//in c# i decoratori sono implementati utilizzando gli attributi, per usarli:
using System.ComponentModel.DataAnnotations;




//tramite i decorators possiamo validare i dati di input di una classe, ad esempio in un modello di dati o in un controller
//ad esempio la classe rubrica, cioè:

public class LastId
{
    public int Id { get; set; }
}

public class Contatto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public List<string> Interessi { get; set; }
}



//Nella classe LastId possiamo utilizzare il decoratore [Range] per validare che l'ID sia un numero intero positivo:

public class LastId
{
    [Range(0, int.MaxValue, ErrorMessage = "L'ID deve essere un numero intero positivo.")]
    public int Id { get; set; }
}



//questo significa che la classe non accetterà valori negativi per l'ID e restituirà un messaggio di errore:

lastId.Id = -1; // questo è un valore non valido
// context indica l'oggetto da validare, in questo caso lastId
var context = new ValidationContext(lastId);

try
{
    // validate object restituisce un'eccezione se l'oggetto non è valido, altrimenti non restituisce nulla
    Validator.ValidateObject(lastId, context, true);
}
catch (ValidationException ex)
{
    Console.WriteLine(ex.Message);
}



//nella classe Contatto possiamo utilizzare il decoratore [Required] per validare che i campi Nome e Cognome siano obbligatori 
//e validarne eventualmente lunghezza massima e/o minima con [StringLength]

[Required(ErrorMessage = "Il nome è obbligatorio.")]
[StringLength(50, MinimumLength = 2, ErrorMessage = "Il nome deve essere compreso tra 2 e 50 caratteri.")]
public string Nome { get; set; }



//per vedere se la mail è valida (con chiocciola e dominio) utilizzo [EmailAddress]:

[EmailAddress(ErrorMessage = "L'email non è valida.")]
public string Email { get; set; }



//Per il telefono possiamo usare una semplice regular expression che verifica che il numero di telefono contenga solo numeri:

[RegularExpression(@"^\d+$", ErrorMessage = "Il numero di telefono deve contenere solo numeri.")]
public string Telefono { get; set; }



//Per la lista di interessi, possiamo usare il decoratore [MinLength] per validare che la lista contenga almeno un interesse ma non piu di 3:

[MinLength(1, ErrorMessage = "La lista di interessi deve contenere almeno un interesse.")]
[MaxLength(3, ErrorMessage = "La lista di interessi non può contenere più di 3 interessi.")]
public List<string> Interessi { get; set; }
