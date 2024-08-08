namespace UMedia.WebAPI.Contract.V1_0.Workspace;

[SwaggerSchema("The response with the workspace")]
public sealed class GetWorkspaceResponse
{
    [SwaggerSchema("The workspace")]
    public required WorkspaceRecord Workspace { get; set; }
}
