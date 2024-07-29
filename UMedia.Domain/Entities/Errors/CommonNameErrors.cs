namespace UMedia.Domain.Entities.Errors;

internal static class CommonNameErrors
{
    public static readonly ValidationError IsNotUnique = new()
    {
        Identifier = $"{nameof(CommonNameConstraints)}.{nameof(IsNotUnique)}",
        ErrorMessage = "The name should be unique."
    };

    public static readonly ValidationError IsNullOrEmpty = new()
    {
        Identifier = $"{nameof(CommonNameConstraints)}.{nameof(IsNullOrEmpty)}",
        ErrorMessage = "The name should not be null or empty."
    };

    public static readonly ValidationError StartsWithWhiteSpace = new()
    {
        Identifier = $"{nameof(CommonNameConstraints)}.{nameof(StartsWithWhiteSpace)}",
        ErrorMessage = "The name should not start with a white space."
    };

    public static readonly ValidationError LengthIsOutOfRange = new()
    {
        Identifier = $"{nameof(CommonNameConstraints)}.{nameof(LengthIsOutOfRange)}",
        ErrorMessage = $"The length of the name should not be less than {CommonNameConstraints.MinimumLength} or more than {CommonNameConstraints.MaximumLength}."
    };
}
