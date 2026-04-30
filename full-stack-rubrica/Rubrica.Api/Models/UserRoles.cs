namespace Rubrica.Api.Models;

public static class UserRoles
{
    // costanti semplici per evitare errori di scrittura nei nomi ruolo
    public const string Admin = "Admin";
    public const string Editor = "Editor";
    public const string User = "User";

    //Comoda costante da usare in [Authorize(Roles = ...)]
    public const string AdminOrEditor = "Admin,Editor";
}