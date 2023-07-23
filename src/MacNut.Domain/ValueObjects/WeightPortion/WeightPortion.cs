namespace MacNut.Types;

public class WeightPortion : ValueObject<float,WeightPortion>
{

    private WeightPortionUnit _weightPortionUnit = WeightPortionUnit.Per100Gram;

    public static WeightPortion From(double value, WeightPortionUnit weightPortionUnit) => 
        From((float)value, weightPortionUnit);

    public static WeightPortion From(float value, WeightPortionUnit weightPortionUnit)
    {
        var newObject = new WeightPortion
        {
            Value = value,
            _weightPortionUnit = weightPortionUnit,
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors, typeof(WeightPortion), value!);
        }

        return newObject;
    }

    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (Value < 0)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Weight portion values must be positive."));
        }

        return result;
    }

    public override string ToString()
    {
        return $"{Value} {_weightPortionUnit}";
    }
}
