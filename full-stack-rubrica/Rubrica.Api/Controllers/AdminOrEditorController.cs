using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rubrica.Api.Dtos;
using Rubrica.Api.Models;
using Rubrica.Api.Services;

namespace Rubrica.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
// Limitiamo l'accesso a tutta la classe solo ai ruoli di Admin ed Editor
[Authorize(Roles = UserRoles.AdminOrEditor)] 
public class AdminOrEditorController : ControllerBase
{
    private readonly AuthService _authService;

    public AdminOrEditorController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllUsers()
    {
        List<UserStampDto> users = await _authService.GetAllUsersProfileAsync();
        return Ok(users);
    }
}