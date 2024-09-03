namespace UMedia.WebAPI.Contract.V1_0.Image;

[SwaggerSchema("The request to create the image")]
public sealed class PostImageRequest
{
    [SwaggerSchema("The ID of the workspace that will contain the image")]
    [SwaggerSchemaExample("1")]
    public required int WorkspaceId { get; set; }

    [SwaggerSchema("The image name")]
    [SwaggerSchemaExample("Some name")]
    public required string Name { get; set; }
}
