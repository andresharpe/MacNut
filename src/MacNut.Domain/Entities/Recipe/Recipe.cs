using MacNut.Types;

namespace MacNut.Domain.Entities.Recipe;

public class Recipe
{
    public int Id { get; set; }

    public Text Name { get; set; }

    IReadOnlyList<Ingredient> Ingredients { get; set; }

    public Recipe(int id, string name, IReadOnlyList<Ingredient> ingredients)
    {

        Id = id;
        Name = Text.From(name);
        Ingredients = ingredients;
    }

}
