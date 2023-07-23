namespace MacNut.Types;

public class TypeValidationException : Exception
{

    private IList<ValidationFailure> _errors = new List<ValidationFailure>();

    public IReadOnlyList<ValidationFailure> Errors => _errors.ToList();

    public TypeValidationException(IList<ValidationFailure> errors, Type type, object value)
    : base($"Validation failed creating type [{type}] using value [{value}] ({errors.Count} error(s)).")
    {
        _errors = errors;
    }

}