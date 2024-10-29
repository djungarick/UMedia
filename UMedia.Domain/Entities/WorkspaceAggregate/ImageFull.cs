namespace UMedia.Domain.Entities.WorkspaceAggregate;

public sealed class ImageFull
{
    private static Result? s_validContentAndSupportedFormatButWidthOrHeightOrFormatAreMissed;

    private ImageFull()
    {
    }

    public int ImageId { get; private set; }

    public IEnumerable<byte> Data { get; private set; } = [];

    public int Width { get; private set; }

    public int Height { get; private set; }

    public string Format { get; private set; } = null!;

#pragma warning disable IDE0046 // Convert to conditional expression
    public static Result<ImageFull> Create(int imageId,
        scoped ReadOnlySpan<byte> data,
        int? width,
        int? height,
        string? format,
        bool isValidContent,
        bool isSupportedFormat)
    {
        Result contentAndFormatCheckResult = ImageFullConstraints.Check(isValidContent, isSupportedFormat);
        if (!contentAndFormatCheckResult.IsSuccess)
            return contentAndFormatCheckResult;

        if (width is null || height is null || format is null)
        {
            return s_validContentAndSupportedFormatButWidthOrHeightOrFormatAreMissed
                ??= Result.CriticalError($"Because of the image has valid content and the supported format, '{nameof(width)}', '{nameof(height)}' and '{nameof(format)}' have not to be null.");
        }

        return new ImageFull
        {
            ImageId = imageId,
            Data = data.ToArray(),
            Width = width.Value,
            Height = height.Value,
            Format = format
        };
    }
#pragma warning restore IDE0046 // Convert to conditional expression

    public void UpdateImageId(int imageId)
        => ImageId = imageId;
}
