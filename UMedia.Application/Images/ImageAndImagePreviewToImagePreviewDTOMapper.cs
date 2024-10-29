namespace UMedia.Application.Images;

internal static class ImageAndImagePreviewToImagePreviewDTOMapper
{
    // TODO: Reuse ImagePreviewToImagePreviewDTOMapper.Expression.
    public static readonly Expression<Func<Image, ImagePreview?, ImageShortInfoDTO>> Expression = static (image, preview)
        => new ImageShortInfoDTO(image.Id,
            image.Name,
            preview == null
                ? null
                : new ImagePreviewDTO(preview.Width, preview.Height, preview.Format, preview.Data));

    public static readonly Func<Image, ImagePreview?, ImageShortInfoDTO> Func = Expression.Compile();
}
