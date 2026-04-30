using System.ComponentModel.DataAnnotations;

namespace Rubrica.Api.Dtos;

public class LoginDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    //non serve lo stringlength perché deve confrontare con l'originale, quindi poco ci cambia se inserisce 6k caratteri, dato che il limite imposto dal decorators lo ha già l'originale nella quale viene creata la password
    public string Password { get; set; } = string.Empty;
}