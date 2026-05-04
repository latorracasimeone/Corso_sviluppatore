using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Rubrica.Api.Data;
using Rubrica.Api.Models;

namespace Rubrica.Api.Seed;

public static class DataSeeder
{
    // Questo metodo crea utenti e interessi iniziali.
    // se i dati esistono già, non li duplica.
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        {
        //lo scope serve a garantire che i servizi vengano rilasciati correttamente. Using di validità di applicazione pipeline. 
        //In particolare ApplicationDbContext e UserManager<ApplicationUser> (models?)

        ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        UserManager<ApplicationUser> userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        RoleManager<IdentityRole> roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        //creiamo i ruoli se non esistono
        await EnsureRoleExistsAsync(roleManager, UserRoles.Admin);
        await EnsureRoleExistsAsync(roleManager, UserRoles.Editor);
        await EnsureRoleExistsAsync(roleManager, UserRoles.User);
        

        // Creiamo alcuni utenti demo
        ApplicationUser utente1 = await CreateUserIfNotExistsAsync(
            userManager,
            "utente1@email.com",
            "123456",
            "Utente uno",
            "3331234567",
            false,
            new DateTime(1990, 1, 1));

        ApplicationUser utente2 = await CreateUserIfNotExistsAsync(
            userManager,
            "utente2@email.com",
            "123456",
            "Utente due",
            "3337654321",
            true,
            new DateTime(1985, 5, 15));
        ApplicationUser utente3 = await CreateUserIfNotExistsAsync(
            userManager,
            "utente3@email.com",
            "123456",
            "Utente tre",
            "3331112222",
            true,
            new DateTime(1999, 09, 10));

        // assegnamo i ruoli
        await EnsureSingleRoleAsync(userManager, utente1, UserRoles.Admin);
        await EnsureSingleRoleAsync(userManager, utente2, UserRoles.Editor);
        await EnsureSingleRoleAsync(userManager, utente3, UserRoles.User);

        // Creiamo alcuni interessi per ogni utente
        await CreateInterestIfNotExistsAsync(context, utente1.Id, "F1");
        await CreateInterestIfNotExistsAsync(context, utente1.Id, "CSharp");
        await CreateInterestIfNotExistsAsync(context, utente1.Id, "Cinema");

        await CreateInterestIfNotExistsAsync(context, utente2.Id, "Dragon Ball");
        await CreateInterestIfNotExistsAsync(context, utente2.Id, "Angular");
        await CreateInterestIfNotExistsAsync(context, utente2.Id, "Musica");

        await CreateInterestIfNotExistsAsync(context, utente3.Id, "Lettura");
        await CreateInterestIfNotExistsAsync(context, utente3.Id, "Spider-Man");
        await CreateInterestIfNotExistsAsync(context, utente3.Id, "Inter");
        await CreateInterestIfNotExistsAsync(context, utente3.Id, "Timone");
        await CreateInterestIfNotExistsAsync(context, utente3.Id, "HULK");
        
        //prova a cercare awiat per aggiornare invece di creare un interesse se non esiste async!!!!!
        /////Forse con un metodo tipo UpdateInterestIfNotPiripillo???????
        }
    }

    private static async Task EnsureRoleExistsAsync(RoleManager<IdentityRole> roleManager, string roleName)
    {
        bool exists = await roleManager.RoleExistsAsync(roleName);

        if (!exists)
        {
            IdentityRole role = new IdentityRole();
            role.Name = roleName;

            await roleManager.CreateAsync(role);
        }
    }

    private static async Task<ApplicationUser> CreateUserIfNotExistsAsync(
        UserManager<ApplicationUser> userManager,
        string email,
        string password,
        string nomeCompleto,
        string? phoneNumber,
        bool NumeroInternazionale,
        DateTime? Birthday)
    {
        // Controlliamo se l'utente esiste già tramite email
        ApplicationUser? existingUser = await userManager.FindByEmailAsync(email);

        if (existingUser != null)
        {
            return existingUser;
        }

        ApplicationUser user = new ApplicationUser();
        user.UserName = email;
        user.Email = email;
        user.NomeCompleto = nomeCompleto;
        user.PhoneNumber = phoneNumber;
        user.CreatedAt = DateTime.UtcNow;
        user.NumeroInternazionale = NumeroInternazionale;
        user.Birthday = Birthday;
        

        IdentityResult result = await userManager.CreateAsync(user, password);

        if (!result.Succeeded)
        {
            List<string> errors = new List<string>();

            foreach (IdentityError error in result.Errors)
            {
                errors.Add(error.Description);
            }

            string message = string.Join(" | ", errors);
            throw new Exception($"Errore durante la creazione dell'utente {email}: {message}");
        }

        return user;
    }

    private static async Task EnsureSingleRoleAsync(
        UserManager<ApplicationUser> userManager,
        ApplicationUser user,
        string targetRole)
    {
        IList<string> currentRoles = await userManager.GetRolesAsync(user);

        //rimuoviamo i ruoli classici se diversi da quello target
        for (int i = 0; i < currentRoles.Count; i++)
        {
            string currentRole = currentRoles[i];

            if (currentRole == UserRoles.Admin ||
                currentRole == UserRoles.Editor ||
                currentRole == UserRoles.User)
            {
                if (currentRole != targetRole)
                {
                    await userManager.RemoveFromRoleAsync(user, currentRole);
                }
            }
        }

        bool alreadyInTargetRole = await userManager.IsInRoleAsync(user, targetRole);

        if (!alreadyInTargetRole)
        {
            await userManager.AddToRoleAsync(user, targetRole);
        }
    }



    private static async Task CreateInterestIfNotExistsAsync(
        ApplicationDbContext context,
        string userId,
        string nome)
    {
        // Leggiamo tutti gli interessi e controlliamo a mano
        // se questo interesse esiste già per quell'utente.
        List<Interest> interests = await context.Interests.ToListAsync();

        for (int i = 0; i < interests.Count; i++)
        {
            Interest currentInterest = interests[i];

            bool sameUser = currentInterest.UserId == userId;
            bool sameName = string.Equals(currentInterest.Nome, nome, StringComparison.OrdinalIgnoreCase);

            if (sameUser && sameName)
            {
                return;
            }
        }

        Interest interest = new Interest();
        interest.UserId = userId;
        interest.Nome = nome;

        context.Interests.Add(interest);
        await context.SaveChangesAsync();
    }
}