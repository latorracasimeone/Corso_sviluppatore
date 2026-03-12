using System.ComponentModel.DataAnnotations;
public class Contatto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Il nome è obbligatorio.")]
    [StringLength(20, ErrorMessage = "Il nome non può superare i 20 caratteri.")]
    public string Nome { get; set; }
    [RegularExpression(@"^\d+$", ErrorMessage = "Il numero di telefono deve contenere solo numeri.")]//il decorator va messo sempre prima della funzione a cui si vuole applicare la validazione, in questo caso il numero di telefono del contatto, e serve per assicurarsi che il numero di telefono inserito dall'utente contenga solo cifre, senza spazi o altri caratteri. Se l'input non rispetta questa regola, viene mostrato un messaggio di errore all'utente.
    public string Numero { get; set; }
    public bool Presente { get; set; }
    [MinLength(1, ErrorMessage = "La lista di interessi deve contenere almeno un interesse.")]
    [MaxLength(4, ErrorMessage = "La lista di interessi non può contenere più di 4 interessi.")]
    public List<string> Interessi { get; set; } 
}