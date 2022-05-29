using GameStore.DAL.Entites;
using Microsoft.EntityFrameworkCore;

namespace GameStore.DAL;
public class DatabaseContext : DbContext
{
    public DbSet<Game> Games { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Studio> Studios { get; set; }

    public DatabaseContext()
    {
        
        //Database.EnsureDeleted();
        //Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Studio>().HasData(new Studio[]
        {
            new Studio{ Id = 1, Name = "Valve"},
            new Studio{ Id = 2, Name = "Activision Blizzard"},
            new Studio{ Id = 3, Name = "Sony"},
            new Studio{ Id = 4, Name = "Nintendo"}
        });
        modelBuilder.Entity<Genre>().HasData(new Genre[]
        {
            new Genre{ Id = 1, Name = "Horror"},
            new Genre{ Id = 2, Name = "Action"},
            new Genre{ Id = 3, Name = "RTS"},
            new Genre{ Id = 4, Name = "RPG"}
        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseNpgsql(@"Host=localhost;Port=5432;Database=GameStore;Username=postgres;Password=121366");
        }
    }
}
