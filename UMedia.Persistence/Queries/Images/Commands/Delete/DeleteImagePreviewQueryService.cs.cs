using MongoDB.Driver;
using UMedia.Application.Images.Commands.Delete;

namespace UMedia.Persistence.Queries.Images.Commands.Delete;

internal sealed class DeleteImagePreviewQueryService(IOptions<ImagePreviewDatabaseSettings> imagePreviewDatabaseSettingsOptions)
    : ImagePreviewQueryService(imagePreviewDatabaseSettingsOptions),
    IDeleteImagePreviewQueryService
{
    public async Task<long> DeleteAsync(int imageId, CancellationToken cancellationToken)
        => (await ImagePreviewMongoCollection.DeleteOneAsync(_ => _.ImageId == imageId, cancellationToken)).DeletedCount;
}
