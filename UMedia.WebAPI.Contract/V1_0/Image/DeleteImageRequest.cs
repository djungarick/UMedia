namespace UMedia.WebAPI.Contract.V1_0.Image;

public sealed class DeleteImageRequest
{
    [SwaggerParameter("The image ID")]
    [SwaggerSchemaExample("1")]
    public required int Id { get; set; }
}
