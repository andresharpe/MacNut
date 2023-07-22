using MacNut.Types;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MacNut.Infrastructure;

public class WeightPortionConverter : ValueConverter<WeightPortion, float>
{
    public WeightPortionConverter() : base(weightPortion => weightPortion.Value, weightValue => WeightPortion.From(weightValue)) { }
}