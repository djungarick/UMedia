namespace UMedia.Application.Images.Commands.Create;

public interface ICreateImagePreviewQueryService
{
    public Task CreateAsync(ImagePreview imagePreview, CancellationToken cancellationToken = default);
}
