namespace UMedia.Domain.Entities.Errors;

internal static class ImagePreviewErrors
{
    public static readonly ValidationError WidthIsOutOfRange = new()
    {
        Identifier = $"{nameof(ImagePreviewErrors)}.{nameof(WidthIsOutOfRange)}",
        ErrorMessage = $"The image preview width should not be more than {ImagePreviewConstraints.MaxWidth}."
    };

    public static readonly ValidationError HeightIsOutOfRange = new()
    {
        Identifier = $"{nameof(ImagePreviewErrors)}.{nameof(HeightIsOutOfRange)}",
        ErrorMessage = $"The image preview height should not be more than {ImagePreviewConstraints.MaxHeight}."
    };
}
