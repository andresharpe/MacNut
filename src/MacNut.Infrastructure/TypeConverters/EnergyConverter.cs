using MacNut.Types;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MacNut.Infrastructure;

public class EnergyConverter : ValueConverter<Energy, float>
{
    public EnergyConverter() : base(energy => energy.Value, energyValue => Energy.FromDatabase(energyValue)) { }
}