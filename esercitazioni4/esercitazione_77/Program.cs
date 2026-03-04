using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Contracts;

// devo creare un'istanza della classe LastIdController per poter utilizzare il metodo GetNextId, che è un metodo di ISTANZA!!!!!!
var lastIdController = new LastIdController();
int nextId = lastIdController.GetNextId();
Console.WriteLine($"Il nuovo ID è: {nextId}");



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



public class LastId
{
    [Range(0, int.MaxValue, ErrorMessage = "L'Id deve essere un numero intero positivo")]
    public int Id { get; set; }
}

public static class JsonHelper
{
    public static void Salva(string path, object obj)
    {
        string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
        File.WriteAllText(path, json);
    }

    public static T Leggi<T>(string path)
    {
        // ATTENZIONE: Qui avevi un errore logico! 
        // Se il file ESISTE, devi leggerlo, non ritornare default.
        if (!File.Exists(path))
        {
            return default(T);
        }
        string json = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<T>(json);
    }
}










//sezioni da separare, preso da esercitazione73:

