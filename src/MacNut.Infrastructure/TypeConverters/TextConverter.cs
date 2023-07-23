using MacNut.Types;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MacNut.Infrastructure;

public class TextConverter : ValueConverter<Text, string>
{
    public TextConverter() : base(text => text.Value, textValue => Text.FromDatabase(textValue)) { }
}