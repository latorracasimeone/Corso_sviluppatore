using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rubrica.Api.Dtos;
using Rubrica.Api.Models;
using Rubrica.Api.Services;

namespace Rubrica.Api.Controllers;

 [ApiController]
 [Route("api/[controller]")]
 [Authorize(Roles = UserRoles.Admin)]
 public class AdminUsersController : ControllerBase
 {
    private readonly UserRoleService _userRoleService;

    public AdminUsersController(UserRoleService userRoleService)
    {
        _userRoleService = userRoleService;
    }

    [HttpPut("change-role")]
    public async Task<IActionResult> ChangeRole([FromBody] ChangeUserRoleDto dto)
    {
        string? newRole = await _userRoleService.ChangeUserRoleAsync(dto);

        if (newRole == null)
        {
            return BadRequest(new { message = "Utente o ruolo non valido. " });//400
        }

        return Ok(new
        {
            message = "Ruolo aggiornato correttamente.  ",
            email = dto.Email,
            role = newRole
        });
    }
 }