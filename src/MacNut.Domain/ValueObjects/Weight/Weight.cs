namespace MacNut.Types;

/// <summary>
/// Represents a Nox <see cref="Weight"/> type and value object.
/// </summary>
public class Weight : ValueObject<float, Weight>
{

    private WeightUnit _weightUnit = WeightUnit.Grams;

    /// <summary>
    /// Creates a new instance of <see cref="Weight"/> object in grams.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Weight"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Weight FromGrams(float value)
        => From(value, WeightUnit.Grams);


    /// <summary>
    /// Creates a new instance of <see cref="Weight"/> object in kilograms.
    /// </summary>
    /// <param name="value">The origin value to create the <see cref="Weight"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public new static Weight From(float value)
        => From(value, WeightUnit.Grams);

    public static Weight From(float value, WeightUnit weightUnit)
    {
        var newObject = new Weight
        {
            Value = value,
            _weightUnit = weightUnit, 
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors, typeof(Weight), value!);
        }

        return newObject;
    }

    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (Value < 0)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Weight values must be positive."));
        }

        return result;
    }

    public override string ToString()
    {
        return $"{Value} {_weightUnit}";
    }

}