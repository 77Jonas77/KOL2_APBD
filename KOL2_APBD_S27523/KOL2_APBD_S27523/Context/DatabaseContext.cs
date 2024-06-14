using KOL2_APBD_S27523.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace KOL2_APBD_S27523.Context;

public class DatabaseContext : DbContext
{
    public DbSet<Item> Items { get; set; }
    public DbSet<Title> Titles { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<BackpackSlot> BackpackSlots { get; set; }
    public DbSet<CharacterTitle> CharacterTitles { get; set; }

    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(
            "Server=localhost;Database=APBDKOL2;User Id=sa;Password=MyPass@word;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BackpackSlot>()
            .HasKey(bs => new { bs.CharacterId, bs.ItemId });

        modelBuilder.Entity<CharacterTitle>()
            .HasKey(ct => new { ct.CharacterId, ct.TitleId });

        modelBuilder.Entity<Item>().HasData(
            new Item { Pk = 1, Name = "Steel Sword", Weight = 5 },
            new Item { Pk = 2, Name = "Silver Sword", Weight = 6 },
            new Item { Pk = 3, Name = "Witcher Medallion", Weight = 1 }
        );

        modelBuilder.Entity<Title>().HasData(
            new Title { Pk = 1, Name = "Witcher" },
            new Title { Pk = 2, Name = "Sorceress" }
        );

        modelBuilder.Entity<Character>().HasData(
            new Character
            {
                Pk = 1,
                FirstName = "Geralt",
                LastName = "of Rivia",
                MaxWeight = 100,
                CurrentWeight = 20,
                Money = 1000
            },
            new Character
            {
                Pk = 2,
                FirstName = "Yennefer",
                LastName = "of Vengerberg",
                MaxWeight = 80,
                CurrentWeight = 10,
                Money = 500
            }
        );

        modelBuilder.Entity<BackpackSlot>().HasData(
            new BackpackSlot { CharacterId = 1, ItemId = 1 },
            new BackpackSlot { CharacterId = 1, ItemId = 2 },
            new BackpackSlot { CharacterId = 2, ItemId = 3 }
        );

        modelBuilder.Entity<CharacterTitle>().HasData(
            new CharacterTitle { CharacterId = 1, TitleId = 1, AcquiredAt = DateTime.Now.AddDays(-30) },
            new CharacterTitle { CharacterId = 2, TitleId = 2, AcquiredAt = DateTime.Now.AddDays(-20) }
        );
    }
}