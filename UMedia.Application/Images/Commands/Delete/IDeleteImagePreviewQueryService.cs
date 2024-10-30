namespace UMedia.Application.Images.Commands.Delete;

public interface IDeleteImagePreviewQueryService
{
    public Task<long> DeleteAsync(int imageId, CancellationToken cancellationToken = default);
}
