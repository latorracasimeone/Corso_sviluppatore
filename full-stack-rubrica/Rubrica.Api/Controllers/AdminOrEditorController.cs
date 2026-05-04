using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rubrica.Api.Dtos;
using Rubrica.Api.Models;
using Rubrica.Api.Services;

namespace Rubrica.Api.Controllers;

[ApiController]
[Route("api/[controller]")]/* <- con questa "parolina magica" ASP.NET prende in automatico il nome della classe,
ma tagliando via la parola "Controller" qui fra parentesi quadre ed usa quel che resta.*/
// Limitiamo l'accesso a tutta la classe solo ai ruoli di Admin ed Editor
[Authorize(Roles = UserRoles.AdminOrEditor)] 
public class AdminOrEditorController : ControllerBase
{
    private readonly AuthService _authService;

    public AdminOrEditorController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpGet("all")]/* <- questa è la fine dell'url! che alla fine è:
    http://localhost:5062/api/AdminOrEditor/all*/
    public async Task<IActionResult> GetAllUsers()
    {
        List<UserStampDto> users = await _authService.GetAllUsersProfileAsync();
        return Ok(users);
    }
}