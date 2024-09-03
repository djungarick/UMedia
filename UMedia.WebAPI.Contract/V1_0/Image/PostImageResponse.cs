namespace UMedia.WebAPI.Contract.V1_0.Image;

[SwaggerSchema("The response with the ID of the created image")]
public sealed class PostImageResponse
{
    [SwaggerSchema("The image ID")]
    [SwaggerSchemaExample("1")]
    public required int Id { get; set; }
}
