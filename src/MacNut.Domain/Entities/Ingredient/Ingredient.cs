using MacNut.Types;

namespace MacNut.Domain;

public class Ingredient
{
    public int Id { get; internal set; }

    public Text Description { get; internal set; }

    public ProductCategory ProductCategory { get; internal set; }

    public Weight Weight { get; internal set; }

    public Ingredient(int id, string description, ProductCategory category, Weight weight)
    {
        Id = id;
        Description = Text.From(description);
        ProductCategory = category;
        Weight = weight;
    }
}
