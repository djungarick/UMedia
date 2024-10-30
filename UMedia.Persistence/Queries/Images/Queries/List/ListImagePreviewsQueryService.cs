using MongoDB.Driver;
using UMedia.Application.Images.Queries.ListShortInfo;
using UMedia.Domain.Entities.WorkspaceAggregate;

namespace UMedia.Persistence.Queries.Images.Queries.List;

internal sealed class ListImagePreviewsQueryService(IOptions<ImagePreviewDatabaseSettings> imagePreviewDatabaseSettingsOptions)
    : ImagePreviewQueryService(imagePreviewDatabaseSettingsOptions),
    IListImagePreviewsQueryService
{
    public async Task<IEnumerable<ImagePreview>> ListReadOnlyAsync(IEnumerable<int> imageIds, CancellationToken cancellationToken)
        => await ImagePreviewMongoCollection.Find(_ => imageIds.Contains(_.ImageId))
            .ToListAsync(cancellationToken);
}
