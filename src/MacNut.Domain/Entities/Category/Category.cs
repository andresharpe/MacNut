using MacNut.Types;

namespace MacNut.Domain;

public class Category
{
    public Text Id { get; set; } = default!;

    public List<Product> Products { get; set; } = default!;

    public Category() { }

    public Category(string id)
    {
        Id = Text.From(id);
    }
}
