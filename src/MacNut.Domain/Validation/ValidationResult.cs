namespace MacNut.Types;

internal class ValidationResult
{

    public bool IsValid => Errors.Count == 0;

    public List<ValidationFailure> Errors { get; set; } = new();
}