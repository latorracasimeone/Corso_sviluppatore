using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Rubrica.Api.Models;

namespace Rubrica.Api.Helpers;
//riceve dati e crea un token sicuro e firmato.
public class JwtHelper
{
    private readonly IConfiguration _configuration;//_configuration viene usato per accedere ai dati di configurazione JWT (?) 

    public JwtHelper(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(ApplicationUser user)///riceviamo un'istnaza di ApplicationUser perché il token che dobbiamo creare deve contenere le informaizoni dell'utente
    {
        // Leggiamo i dati dal file appsettings.json
        string? key = _configuration["Jwt:Key"];
        string? issuer = _configuration["Jwt:Issuer"];
        string? audience = _configuration["Jwt:Audience"];

        if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(issuer) || string.IsNullOrEmpty(audience))
        {
            throw new Exception("Configurazione JWT mancante.");
        }

        // Dentro il token mettiamo alcune informazioni utili
        Claim[] claims = new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName ?? ""),
            new Claim(ClaimTypes.Email, user.Email ?? "")
        };

        //secret key generata in automatico(?)
        SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));//UTF8 encoding europeo, solo quei caratteri (es: non c'è "è" accentata)
        SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}