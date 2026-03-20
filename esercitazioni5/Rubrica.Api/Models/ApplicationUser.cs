using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rubrica.Api.Models;

[Table("Users")]//specifica il nome della tabella nel database
public class ApplicationUser : IdentityUser
{
    // IdentityUser ha già:
    // Id, UserName, Email, PasswordHash, PhoneNumber, ecc.
    //noi andiamo ad aggiungere

    [Required]
    [StringLength(100)]
    public string NomeCompleto { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Un utente può avere molti interessi (Relazione uno-a-molti)
    public List<Interest> Interests { get; set; } = new List<Interest>();
    public bool NumeroInternazionale { get; set; } 
    
    [DataType(DataType.Date)] // Suggerisce al front-end di usare un selettore di date
    public DateTime? Birthday { get; set; }//il punto interrogativo indica che è nullable, ovvero può essere null se l'utente non ha inserito la data di nascita
}
