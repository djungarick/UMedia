namespace UMedia.WebAPI.Contract.V1_0.Workspace;

[SwaggerSchema("The response with the created workspace")]
public sealed class PostWorkspaceResponse
{
    [SwaggerSchema("The workspace ID")]
    [SwaggerSchemaExample("1")]
    public required int Id { get; set; }
}
