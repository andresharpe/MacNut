using System.Text.RegularExpressions;

namespace MacNut.Types;

/// <summary>
/// Represents a Nox <see cref="Text"/> type and value object. 
/// </summary>
public sealed class ProductCode : ValueObject<string, ProductCode>
{
    // https://stackoverflow.com/questions/46782710/regex-for-upc-a-type-barcodes
    private static Regex _upcRegex = new Regex("^(?=.*0)[0-9]{12}$", RegexOptions.Compiled, TimeSpan.FromSeconds(1));
    private static Regex _eanRegex = new Regex("^(?=.*0)[0-9]{13}$", RegexOptions.Compiled, TimeSpan.FromSeconds(1));

    public ProductCode() { Value = string.Empty; }

    /// <summary>
    /// Validates a <see cref="Text"/> object.
    /// </summary>
    /// <returns>true if the <see cref="Text"/> value is valid according to the default or specified <see cref="TextTypeOptions"/>.</returns>
    /// <exception cref="NotImplementedException">If the <see cref="TextTypeCasing"/> is not implemented by this method.</exception>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

       if (!(_upcRegex.IsMatch(Value) || _eanRegex.IsMatch(Value)))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Invalid code. Must be a valid EAN or UPC code."));
        }

        return result;
    }
}