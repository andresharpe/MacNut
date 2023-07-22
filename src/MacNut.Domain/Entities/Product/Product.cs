using MacNut.Types;

namespace MacNut.Domain;

public class Product
{
    public ProductCode Id { get; } 
    public Text Name { get; }
    public Text Manufacturer { get;  }
    public Weight Weight { get; }
    public Energy Energy { get; }
    public WeightPortion Fats { get; }
    public WeightPortion SaturatedFats { get; }
    public WeightPortion Carbs { get; }
    public WeightPortion Sugars { get; }
    public WeightPortion Fibres { get; }
    public WeightPortion Proteins { get; }
    public WeightPortion Salts { get; }

    public IReadOnlyList<ProductCategory> Categories { get; }

    public Product(ProductCode id, Text name, Text manufacturer, Weight weight, Energy energy, WeightPortion fats, 
        WeightPortion saturatedFats, WeightPortion carbs, WeightPortion sugars, WeightPortion fibres, 
        WeightPortion proteins, WeightPortion salts, IReadOnlyList<ProductCategory> categories)
    {
        Id = id;
        Name = name;
        Manufacturer = manufacturer;
        Weight = weight;
        Energy = energy;
        Fats = fats;
        SaturatedFats = saturatedFats;
        Carbs = carbs;
        Sugars = sugars;
        Fibres = fibres;
        Proteins = proteins;
        Salts = salts;
        Categories = categories;
    }   
}
