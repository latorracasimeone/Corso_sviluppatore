using Microsoft.AspNetCore.Identity;
using Rubrica.Api.Dtos;
using Rubrica.Api.Helpers;
using Rubrica.Api.Models;

namespace Rubrica.Api.Services;

public class AuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly JwtHelper _jwtHelper; 

    public AuthService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        JwtHelper jwtHelper)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtHelper = jwtHelper;
    }

    public async Task<IdentityResult> RegisterAsync(RegisterDto dto)
    {
        ApplicationUser? existingUser = await _userManager.FindByEmailAsync(dto.Email);

        if (existingUser != null)
        {
            IdentityError error = new IdentityError { Description = "Email già registrata." };
            List<IdentityError> errors = new List<IdentityError> { error };
            return IdentityResult.Failed(errors.ToArray());
        }

        ApplicationUser user = new ApplicationUser
        {
            UserName = dto.Email,
            Email = dto.Email,
            NomeCompleto = dto.NomeCompleto,
            PhoneNumber = dto.PhoneNumber,
            CreatedAt = DateTime.UtcNow,
            NumeroInternazionale = dto.NumeroInternazionale,
            Birthday = dto.Birthday
        };

        IdentityResult result = await _userManager.CreateAsync(user, dto.Password);

        if (!result.Succeeded)
        {
            return result;
        }

        // MODIFICA: Assegniamo sempre il ruolo "User" di default. 
        // Evitiamo di passarlo dal DTO per non permettere a chiunque di registrarsi come Admin.
        IdentityResult addRoleResult = await _userManager.AddToRoleAsync(user, "User");

        if (!addRoleResult.Succeeded)
        {
            return addRoleResult;
        }

        return result;
    }

    public async Task<AuthResponseDto?> LoginAsync(LoginDto dto)
    {
        ApplicationUser? user = await _userManager.FindByEmailAsync(dto.Email);

        if (user == null)
        {
            return null;
        }

        SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);

        if (!result.Succeeded)
        {
            return null;
        }

        IList<string> userRoles = await _userManager.GetRolesAsync(user);

        string token = _jwtHelper.GenerateToken(user, userRoles);

        AuthResponseDto response = new AuthResponseDto
        {
            Token = token,
            UserId = user.Id,
            Email = user.Email ?? "",
            NomeCompleto = user.NomeCompleto,
            NumeroInternazionale = user.NumeroInternazionale,
            Birthday = user.Birthday,
            Role = userRoles.Count > 0 ? userRoles[0] : "User"
        };

        return response;
    }

    public async Task<UpdateUserDto?> UpdateAsync(UpdateUserDto dto, string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return null; 
        }

        user.NomeCompleto = dto.NomeCompleto;
        user.PhoneNumber = dto.PhoneNumber;
        user.NumeroInternazionale = dto.NumeroInternazionale;

        var result = await _userManager.UpdateAsync(user);

        if (!result.Succeeded)
        {
            return null;
        }

        // MODIFICA: Ho rimosso la logica di aggiornamento del ruolo. 
        // I ruoli dovrebbero essere gestiti esclusivamente dall'AdminUsersController tramite UserRoleService.

        return dto;
    }

    public async Task<IdentityResult?> DeleteAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return null; 
        }

        var result = await _userManager.DeleteAsync(user);
        return result;
    }

    public async Task<UserStampDto?> GetUserProfile(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return null;
        }

        var userRoles = await _userManager.GetRolesAsync(user);

        UserStampDto dto = new UserStampDto
        {
            Id = user.Id,
            NomeCompleto = user.NomeCompleto,
            Email = user.Email ?? "", // Aggiunto ?? "" per sicurezza contro i null
            PhoneNumber = user.PhoneNumber ?? "",
            NumeroInternazionale = user.NumeroInternazionale,
            Birthday = user.Birthday,
            Role = userRoles.Count > 0 ? userRoles[0] : "User"
        };

        return dto;
    }
}