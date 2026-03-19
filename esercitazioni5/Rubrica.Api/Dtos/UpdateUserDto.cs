using System.ComponentModel.DataAnnotations;

namespace Rubrica.Api.Dtos;

public class UpdateUserDto
{

    [Required]
    [StringLength(100)]
    public string NomeCompleto { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;
    public bool NumeroInternazionale { get; set; }
}