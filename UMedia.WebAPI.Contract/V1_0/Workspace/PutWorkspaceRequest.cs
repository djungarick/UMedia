namespace UMedia.WebAPI.Contract.V1_0.Workspace;

[SwaggerSchema("The request to update the workspace")]
public sealed class PutWorkspaceRequest
{
    [SwaggerSchema("The workspace new name")]
    [SwaggerSchemaExample("Some name")]
    public string Name { get; set; } = null!;
}
