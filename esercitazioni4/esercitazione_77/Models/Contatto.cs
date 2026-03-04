public class Contatto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Il nome è obbligatorio.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Il nome deve essere compreso tra 2 e 50 caratteri.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Il cognome è obbligatorio.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Il cognome deve essere compreso tra 2 e 50 caratteri.")]
    public string Cognome { get; set; }

    [EmailAddress(ErrorMessage = "L'email non è valida.")]
    public string Email { get; set; }

    [RegularExpression(@"^\d+$", ErrorMessage = "Il numero di telefono deve contenere solo numeri.")]
    public string Telefono { get; set; }

    [MinLength(1, ErrorMessage = "La lista di interessi deve contenere almeno un interesse.")]
    [MaxLength(3, ErrorMessage = "La lista di interessi non può contenere più di 3 interessi.")]
    public List<string> Interessi { get; set; }
}