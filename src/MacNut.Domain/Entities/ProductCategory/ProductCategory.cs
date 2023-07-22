using MacNut.Types;

namespace MacNut.Domain;

public class ProductCategory
{
    public int Id { get; set; } = default!;

    public Text Name { get; set; } = default!;

    public ProductCategory() { }

    public ProductCategory(int id, string name)
    {
        Name = Text.From(name);
    }
}
