namespace UMedia.Domain.Entities.Errors;

internal static class ImageFullErrors
{
    public static readonly ValidationError IsNotValidContent = new()
    {
        Identifier = $"{nameof(ImageFullErrors)}.{nameof(IsNotValidContent)}",
        ErrorMessage = "The image content is invalid."
    };

    public static readonly ValidationError IsNotSupportedFormat = new()
    {
        Identifier = $"{nameof(ImageFullErrors)}.{nameof(IsNotSupportedFormat)}",
        ErrorMessage = "The image format is not supported."
    };
}
