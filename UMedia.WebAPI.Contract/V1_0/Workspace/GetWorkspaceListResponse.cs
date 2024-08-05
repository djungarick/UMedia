namespace UMedia.WebAPI.Contract.V1_0.Workspace;

[SwaggerSchema("The response with the list of workspaces")]
public sealed class GetWorkspaceListResponse
{
    [SwaggerSchema("The list of workspaces")]
    public required IEnumerable<WorkspaceRecord> Workspaces { get; set; }
}
