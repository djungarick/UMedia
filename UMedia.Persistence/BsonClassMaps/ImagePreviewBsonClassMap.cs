using MongoDB.Bson.Serialization;
using UMedia.Domain.Entities.WorkspaceAggregate;

namespace UMedia.Persistence.BsonClassMaps;

internal static class ImagePreviewBsonClassMap
{
    public static void Register()
        => BsonClassMap.RegisterClassMap<ImagePreview>(
            static classMap =>
            {
                classMap.AutoMap();
                _ = classMap.MapIdMember(static _ => _.ImageId);
            });
}
