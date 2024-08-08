namespace UMedia.WebAPI.Contract.V1_0.Workspace;

[SwaggerSchema("The request to create the workspace")]
public sealed class PostWorkspaceRequest
{
    [SwaggerSchema("The workspace name")]
    [SwaggerSchemaExample("Some name")]
    public required string Name { get; set; }
}
