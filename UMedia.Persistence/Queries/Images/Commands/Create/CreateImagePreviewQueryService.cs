using UMedia.Application.Images.Commands.Create;
using UMedia.Domain.Entities.WorkspaceAggregate;

namespace UMedia.Persistence.Queries.Images.Commands.Create;

internal sealed class CreateImagePreviewQueryService(IOptions<ImagePreviewDatabaseSettings> imagePreviewDatabaseSettingsOptions)
    : ImagePreviewQueryService(imagePreviewDatabaseSettingsOptions),
    ICreateImagePreviewQueryService
{
    public async Task CreateAsync(ImagePreview imagePreview, CancellationToken cancellationToken)
        => await ImagePreviewMongoCollection.InsertOneAsync(imagePreview, cancellationToken: cancellationToken);
}
