using UMedia.Application.Models.Services.ImageFullAndImagePreviewCreator;

namespace UMedia.Application.Interfaces.Services;

public interface IImageFullAndImagePreviewCreatorService
{
    public Result<ImageFullAndImagePreview> Create(scoped ReadOnlySpan<byte> imageFullData);
}
