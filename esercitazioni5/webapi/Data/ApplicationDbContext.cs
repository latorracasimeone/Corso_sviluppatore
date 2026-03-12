using Microsoft.EntityFrameworkCore;
public class ApplicationDbContext : DbContext
{
    //Costruttore che accetta le opzioni di configurazione del dbcontext
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        //qui non serve aggiungere niente, il costruttore base si occupa di configurare il dbcontext con le opzioni fornite in Programs
    }

    //DbSet per la tabella contatti
    public DbSet<Contatto> Contatti { get; set; }
    //DbSet per la tabella Users
    public DbSet<User> Users { get; set; }
}