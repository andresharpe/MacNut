using MacNut.Types;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MacNut.Infrastructure;

public class ProductCodeConverter : ValueConverter<ProductCode, string>
{
    public ProductCodeConverter() : base(code => code.Value, codeValue => ProductCode.From(codeValue)) { }
}