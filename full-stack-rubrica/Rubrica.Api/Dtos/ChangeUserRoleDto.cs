using System.ComponentModel.DataAnnotations;

namespace Rubrica.Api.Dtos;

public class ChangeUserRoleDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string NewRole { get; set; } = string.Empty;
}