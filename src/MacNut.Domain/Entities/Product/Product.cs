using MacNut.Types;

namespace MacNut.Domain;

public class Product
{
    public ProductCode Id { get; set; } = default!;
    public Text Name { get; set; } = default!;  
    public Text Manufacturer { get; set; } = default!;
    public Weight Weight { get; set; } = default!;
    public Energy Energy { get; set; } = default!;
    public WeightPortion Fats { get; set; } = default!;
    public WeightPortion SaturatedFats { get; set; } = default!;
    public WeightPortion Carbs { get; set; } = default!;
    public WeightPortion Sugars { get; set; } = default!;
    public WeightPortion Fibres { get; set; } = default!;
    public WeightPortion Proteins { get; set; } = default!;
    public WeightPortion Salts { get; set; } = default!;

    public IReadOnlyList<ProductCategory> Categories { get; set; } = default!;

    public Product() { }

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
