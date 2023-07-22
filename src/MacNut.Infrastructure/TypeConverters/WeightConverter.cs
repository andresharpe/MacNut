using MacNut.Types;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MacNut.Infrastructure;

public class WeightConverter : ValueConverter<Weight, float>
{
    public WeightConverter() : base(weight => weight.Value, weightValue => Weight.From(weightValue)) { }
}