namespace UMedia.WebAPI.Contract.V1_0.Image;

public sealed class GetImageListRequest
{
    [SwaggerParameter("The workspace ID")]
    [SwaggerSchemaExample("1")]
    public required int WorkspaceId { get; set; }

    [SwaggerParameter("The amount of images to skip")]
    [SwaggerSchemaExample(null)]
    public int? Skip { get; set; }

    [SwaggerParameter("The amount of images to take")]
    [SwaggerSchemaExample(null)]
    public int? Take { get; set; }
}
