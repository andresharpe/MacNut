using MacNut.Types;

namespace MacNut.Domain;

public class Ingredient
{
    public int Id { get; set; } = default!;

    public Text Description { get; set; } = default!;

    public Category ProductCategory { get; set; } = default!;

    public Weight Weight { get; set; } = default!;
    public Ingredient() { }
    public Ingredient(int id, string description, Category category, Weight weight)
    {
        Id = id;
        Description = Text.From(description);
        ProductCategory = category;
        Weight = weight;
    }
}
