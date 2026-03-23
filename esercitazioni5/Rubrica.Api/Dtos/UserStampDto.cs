using System.ComponentModel.DataAnnotations;

namespace Rubrica.Api.Dtos;

public class UserStampDto
{
    public string Id { get; set; } = string.Empty;
    [Required]
    [StringLength(100)]
    public string NomeCompleto { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;
    public bool NumeroInternazionale { get; set; }
    [DataType(DataType.Date)]
    public DateTime? Birthday { get; set; }
    public string Role { get; set; } = string.Empty;
}