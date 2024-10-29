using UMedia.Application.Images.Commands.Create;
using UMedia.Domain.Entities.WorkspaceAggregate;

namespace UMedia.Persistence.Queries.Images.Commands.Create;

internal sealed class CreateImageFullQueryService : ICreateImageFullQueryService
{
    // TODO: Add the Minio S3 storage.
    public Task CreateAsync(ImageFull imageFull, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
