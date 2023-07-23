using MacNut.Domain;
using MacNut.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace MacNut.Infrastructure;

public class MacNutDbContext : DbContext
{
    public MacNutDbContext(DbContextOptions<MacNutDbContext> options): base(options) {}

    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set;}
    public DbSet<Category> ProductCategories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("MacNutDatabase");

            optionsBuilder.UseNpgsql(connectionString);
        }

        base.OnConfiguring(optionsBuilder);
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

        // Category

        modelBuilder.Entity<Category>()
            .ToTable("Categories")
            .Property(p => p.Id)
            .HasConversion<TextConverter>();

        // Product

        modelBuilder.Entity<Product>()
            .Property(p => p.Id)
            .HasConversion<ProductCodeConverter>();

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

        // Seed ProductCategory and Product Data

        var categories = new List<Category>() {
            new Category() { Id = Text.From("en:canned-black-beans") },
            new Category() { Id = Text.From("en:canned-common-beans") },
            new Category() { Id = Text.From("en:black-beans") },
        };

        modelBuilder.Entity<Category>().HasData(categories);

        modelBuilder.Entity<Product>().HasData(
            new Product { 
                Id = ProductCode.From("5601151170755"), 
                Name = Text.From("Haricots noirs"),
                Manufacturer = Text.From("Compal"),
                Weight = Weight.From(234, WeightUnit.Grams),
                Energy = Energy.From(75, EnergyUnit.KCal),
                Fats = WeightPortion.From(0.5, WeightPortionUnit.Per100Gram),
                SaturatedFats = WeightPortion.From(0.1, WeightPortionUnit.Per100Gram),
                Carbs = WeightPortion.From(9.0, WeightPortionUnit.Per100Gram),
                Sugars = WeightPortion.From(0.5, WeightPortionUnit.Per100Gram),
                Fibres = WeightPortion.From(5.5, WeightPortionUnit.Per100Gram),
                Proteins = WeightPortion.From(5.8, WeightPortionUnit.Per100Gram),
                Salts = WeightPortion.From(1.06, WeightPortionUnit.Per100Gram),
            });

        modelBuilder.Entity<Product>()
            .HasMany(p => p.Categories)
            .WithMany(p => p.Products)
            .UsingEntity<Dictionary<string, object>>(
                "ProductCategory",
                r => r.HasOne<Category>().WithMany().HasForeignKey("CategoryId"),
                l => l.HasOne<Product>().WithMany().HasForeignKey("ProductId"),
                je =>
                {
                    je.HasKey("ProductId", "CategoryId");
                    je.HasData(
                        new { ProductId = ProductCode.From("5601151170755"), CategoryId = Text.From("en:canned-common-beans")},
                        new { ProductId = ProductCode.From("5601151170755"), CategoryId = Text.From("en:canned-black-beans") },
                        new { ProductId = ProductCode.From("5601151170755"), CategoryId = Text.From("en:black-beans") }
                    );
                }
            );

        base.OnModelCreating(modelBuilder);
    }
}