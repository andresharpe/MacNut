using MacNut.Types;

namespace MacNut.Domain;

public class Recipe
{
    public int Id { get; set; } = default!;

    public Text Name { get; set; } = default!;

    public List<Ingredient> Ingredients { get; set; } = default!;

    public Recipe() { }

    public Recipe(int id, string name, List<Ingredient> ingredients)
    {

        Id = id;
        Name = Text.From(name);
        Ingredients = ingredients;
    }

}
