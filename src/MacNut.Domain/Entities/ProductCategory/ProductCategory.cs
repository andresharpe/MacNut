using MacNut.Types;

namespace MacNut.Domain;

public class ProductCategory
{
    public int Id { get; set; }
    
    public Text Name { get; }

    public ProductCategory(int id, string name)
    {
        Name = Text.From(name);
    }
}
