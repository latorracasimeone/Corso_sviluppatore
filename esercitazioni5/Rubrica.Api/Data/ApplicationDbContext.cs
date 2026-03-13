using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rubrica.Api.Models;

namespace Rubrica.Api.Data;

public class ApplicationDbContext : IdentityUserContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Interest> Interests { get; set; }

    // Configura le relazioni tra tabelle
    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Prima lasciamo a Identity configurare le sue tabelle standard
        base.OnModelCreating(builder);

        // Configura il collegamento tra utente e interessi
        builder.Entity<Interest>()
            .HasOne(i => i.User)
            .WithMany(u => u.Interests)
            .HasForeignKey(i => i.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}