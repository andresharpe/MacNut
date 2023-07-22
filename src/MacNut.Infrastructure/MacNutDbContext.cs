using MacNut.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace MacNut.Infrastructure;

public class MacNutDbContext : DbContext
{
    public MacNutDbContext(DbContextOptions<MacNutDbContext> options): base(options) {}

    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set;}
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseNpgsql("Host=localhost; Database=macnut; Username=postgres; Password=mysecretpassword;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Recipe

        modelBuilder.Entity<Recipe>()
            .Property(p => p.Name)
            .HasConversion<TextConverter>();

        // Ingredients

        modelBuilder.Entity<Ingredient>()
            .Property(p => p.Description)
            .HasConversion<TextConverter>();

        modelBuilder.Entity<Ingredient>()
            .Property(p => p.Weight)
            .HasConversion<WeightConverter>();

        // ProductCategory

        modelBuilder.Entity<ProductCategory>()
            .Property(p => p.Name)
            .HasConversion<TextConverter>();

        // Product

        modelBuilder.Entity<Product>()
            .Property(p => p.Name)
            .HasConversion<TextConverter>();

        modelBuilder.Entity<Product>()
            .Property(p => p.Manufacturer)
            .HasConversion<TextConverter>();

        modelBuilder.Entity<Product>()
            .Property(p => p.Weight)
            .HasConversion<WeightConverter>();

        modelBuilder.Entity<Product>()
            .Property(p => p.Energy)
            .HasConversion<EnergyConverter>();

        modelBuilder.Entity<Product>()
            .Property(p => p.Fats)
            .HasConversion<WeightPortionConverter>();

        modelBuilder.Entity<Product>()
            .Property(p => p.SaturatedFats)
            .HasConversion<WeightPortionConverter>();

        modelBuilder.Entity<Product>()
            .Property(p => p.Carbs)
            .HasConversion<WeightPortionConverter>();

        modelBuilder.Entity<Product>()
            .Property(p => p.Sugars)
            .HasConversion<WeightPortionConverter>();

        modelBuilder.Entity<Product>()
            .Property(p => p.Fibres)
            .HasConversion<WeightPortionConverter>();

        modelBuilder.Entity<Product>()
            .Property(p => p.Proteins)
            .HasConversion<WeightPortionConverter>();

        modelBuilder.Entity<Product>()
            .Property(p => p.Salts)
            .HasConversion<WeightPortionConverter>();

        modelBuilder.Entity<Product>()
            .Property(p => p.Id)
            .HasConversion<ProductCodeConverter>();

        base.OnModelCreating(modelBuilder);
    }
}