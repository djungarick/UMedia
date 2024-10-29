using MongoDB.Driver;
using UMedia.Domain.Entities.WorkspaceAggregate;

namespace UMedia.Persistence.Queries.Images;

internal class ImagePreviewQueryService
{
    protected readonly IMongoCollection<ImagePreview> ImagePreviewMongoCollection;

    public ImagePreviewQueryService(IOptions<ImagePreviewDatabaseSettings> imagePreviewDatabaseSettingsOptions)
    {
        ImagePreviewDatabaseSettings imagePreviewDatabaseSettings = imagePreviewDatabaseSettingsOptions.Value;

        MongoClient mongoClient = new(imagePreviewDatabaseSettings.ConnectionString);
        IMongoDatabase mongoDatabase = mongoClient.GetDatabase(imagePreviewDatabaseSettings.DatabaseName);
        ImagePreviewMongoCollection = mongoDatabase.GetCollection<ImagePreview>(imagePreviewDatabaseSettings.ImagePreviewsCollectionName);
    }
}
