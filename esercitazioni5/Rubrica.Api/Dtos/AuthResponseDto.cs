using System.Text;

namespace Rubrica.Api.Dtos;
/* i DTO raccolgono i dati che appariranno in FrontEnd grazie 
a TypeScript(?), quindi viene usato come input per l'endpoint di registrazione e login nell'AuthController*/
public class AuthResponseDto
{
    public string Token { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string NomeCompleto { get; set; } = string.Empty;
    public bool NumeroInternazionale { get; set; }
    
    
    public DateTime? Birthday { get; set; }
    
}