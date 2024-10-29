namespace UMedia.Domain.Entities.WorkspaceAggregate;

public sealed class ImagePreview
{
    private ImagePreview()
    {
    }

    public int ImageId { get; private set; }

    public IEnumerable<byte> Data { get; private set; } = [];

    public int Width { get; private set; }

    public int Height { get; private set; }

    public string Format { get; private set; } = null!;

#pragma warning disable IDE0046 // Convert to conditional expression
    public static Result<ImagePreview> Create(int imageId, scoped ReadOnlySpan<byte> data, int width, int height, string format)
    {
        Result imagePreviewCheckResult = ImagePreviewConstraints.Check(width, height);
        if (!imagePreviewCheckResult.IsSuccess)
            return imagePreviewCheckResult;

        return new ImagePreview
        {
            ImageId = imageId,
            Data = data.ToArray(),
            Width = width,
            Height = height,
            Format = format
        };
    }
#pragma warning restore IDE0046 // Convert to conditional expression

    public void UpdateImageId(int imageId)
        => ImageId = imageId;
}
