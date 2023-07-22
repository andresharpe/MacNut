namespace MacNut.Types;

public class Energy : ValueObject<float,Energy>
{

    private EnergyUnit _energyUnit = EnergyUnit.KCal;

    public static Energy From(float value, EnergyUnit energyUnit)
    {
        var newObject = new Energy
        {
            Value = value,
            _energyUnit = energyUnit,
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (Value < 0)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Energy values must be positive."));
        }

        return result;
    }

    public float ToKiloJoules()
    {
        return Value * 4.184f;
    }

    public override string ToString()
    {
        return $"{Value} {_energyUnit}";
    }
}
