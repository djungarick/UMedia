namespace UMedia.WebAPI.Contract.V1_0.Image;

[SwaggerSchema("The response with the list of images")]
public sealed class GetImageListResponse
{
    [SwaggerSchema("The list of images")]
    public required IEnumerable<ImageShortInfoRecord> Images { get; set; }
}
