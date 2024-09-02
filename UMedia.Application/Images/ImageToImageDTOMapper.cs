namespace UMedia.Application.Images;

internal static class ImageToImageDTOMapper
{
    public static readonly Expression<Func<Image, ImageDTO>> Expression = static _ => new ImageDTO(_.Id, _.Name);

    public static readonly Func<Image, ImageDTO> Func = Expression.Compile();
}
