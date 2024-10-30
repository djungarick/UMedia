using UMedia.Application.Images.Commands.Delete;

namespace UMedia.Persistence.Queries.Images.Commands.Delete;

internal sealed class DeleteImageFullQueryService : IDeleteImageFullQueryService
{
    // TODO: Add the Minio S3 storage.
    public Task<long> DeleteAsync(int imageId, CancellationToken cancellationToken)
        => Task.FromResult(0L);
}
