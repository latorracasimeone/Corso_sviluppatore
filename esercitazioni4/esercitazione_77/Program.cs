//LEZIONE 20 DECORATORS

//I decoratori sono un modo di modificare il comportamento di una classe o di un metodo senza modificare il codice originale.
//In C#, i decoratori sono implementati utilizzando gli attributi. Per usarli:
using Newtonsoft.Json;

//Tramite i decorators possiamo validare i dati di input di una classe, ad esempio in un modello di dati, o in un controller. Ad esempio le classi della rubrica, cioè:
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

//nella classe LastId, ad esempio, possiamo usare un decorator per accettare il dato solamente se è un intero positivo
public class lastId
{
    [Range(0, int.MaxValue, ErrorMessage ="L'Id dev'essere un numero naturale intero positivo.")]
    public int Id { get; set; }
}
//questo significa che la classe non accetterà valori negativi per l'ID e restituirà un messaggio di errore se si tenta di assegnare un valore non valido.
//il messaggio di errore può essere stampato in console così:

