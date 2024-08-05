namespace UMedia.WebAPI.Contract.V1_0.Workspace;

[SwaggerSchema("The response with the list of workspaces")]
public sealed class GetWorkspaceListResponse
{
    [SwaggerSchema("The list of workspaces")]
    public IEnumerable<WorkspaceRecord> Workspaces { get; set; } = null!;
}
