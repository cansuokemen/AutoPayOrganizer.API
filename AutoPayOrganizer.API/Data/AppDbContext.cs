using Microsoft.EntityFrameworkCore;
using AutoPayOrganizer.API.Entities; // Expense, Payment, User burada

namespace AutoPayOrganizer.API.Data;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;
        const string cs = "Host=localhost;Port=5432;Database=autopaydb;Username=postgres;Password=1189";
        optionsBuilder.UseNpgsql(cs);
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<Expense> Expenses => Set<Expense>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Username).IsRequired().HasMaxLength(100);
            e.Property(x => x.Email).IsRequired().HasMaxLength(200);
        });

        modelBuilder.Entity<Payment>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Title).IsRequired().HasMaxLength(200);
            e.Property(x => x.Amount).HasColumnType("numeric(18,2)");

            
            e.HasOne(x => x.User)
             .WithMany()                 
             .HasForeignKey(x => x.UserId)
             .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Expense>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Category).IsRequired().HasMaxLength(100);
            e.Property(x => x.Amount).HasColumnType("numeric(18,2)");
            
            
            e.HasOne(x => x.User)
             .WithMany()
             .HasForeignKey(x => x.UserId)
             .OnDelete(DeleteBehavior.Cascade);
        });
    }
}