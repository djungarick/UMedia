namespace UMedia.Application.Images;

internal static class ImagePreviewToImagePreviewDTOMapper
{
    public static readonly Expression<Func<ImagePreview, ImagePreviewDTO>> Expression
            = static _ => new ImagePreviewDTO(_.Width, _.Height, _.Format, _.Data);

    public static readonly Func<ImagePreview, ImagePreviewDTO> Func = Expression.Compile();
}
