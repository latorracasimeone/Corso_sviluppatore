using Microsoft.AspNetCore.Identity;
using Rubrica.Api.Dtos;
using Rubrica.Api.Models;

namespace Rubrica.Api.Services;

public class UserRoleService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserRoleService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }
    public async Task<string?> ChangeUserRoleAsync(ChangeUserRoleDto dto)//ci sarà un modulo dove l'admin può cambiare i ruoli
    {
        //controllo base sul nome ruolo
        if (dto.NewRole != UserRoles.Admin &&
            dto.NewRole != UserRoles.Editor &&
            dto.NewRole != UserRoles.User)
        {
            return null;
        }

        ApplicationUser? user = await _userManager.FindByEmailAsync(dto.Email);

        if (user == null)
        {
            return null;
        }
        IList<string> currentRoles = await _userManager.GetRolesAsync(user);

        //rimuoviamo i ruoli classici già presenti
        for (int i = 0; i < currentRoles.Count; i++)
        {
            string currentRole = currentRoles[i];

            if (currentRole == UserRoles.Admin ||
                currentRole == UserRoles.Editor ||
                currentRole == UserRoles.User)
            {
                await _userManager.RemoveFromRoleAsync(user, currentRole);
            }
        }

        //assegnamo il nuovo ruolo
        IdentityResult addResult = await _userManager.AddToRoleAsync(user, dto.NewRole);

        if (!addResult.Succeeded)
        {
            return null;
        }
        return dto.NewRole;
    }
}