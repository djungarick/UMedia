namespace UMedia.Application.Images.Commands.Delete;

public interface IDeleteImageFullQueryService
{
    public Task<long> DeleteAsync(int imageId, CancellationToken cancellationToken = default);
}
