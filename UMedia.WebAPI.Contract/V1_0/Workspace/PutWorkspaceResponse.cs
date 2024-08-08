namespace UMedia.WebAPI.Contract.V1_0.Workspace;

[SwaggerSchema("The response with the updated workspace")]
public sealed class PutWorkspaceResponse
{
    [SwaggerSchema("The updated workspace")]
    public required WorkspaceRecord Workspace { get; set; }
}
