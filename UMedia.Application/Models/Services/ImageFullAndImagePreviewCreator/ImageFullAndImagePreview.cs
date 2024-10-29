namespace UMedia.Application.Models.Services.ImageFullAndImagePreviewCreator;

public sealed class ImageFullAndImagePreview
{
    public required ImageFull ImageFull { get; init; }

    public required ImagePreview ImagePreview { get; init; }

    public void Deconstruct(out ImageFull imageFull, out ImagePreview imagePreview)
    {
        imageFull = ImageFull;
        imagePreview = ImagePreview;
    }
}
