namespace UMedia.WebAPI.Contract.V1_0.Workspace;

[SwaggerSchema("The response with the list of workspaces")]
public sealed class GetWorkspaceListResponse
{
    [SwaggerSchema("The list of workspaces")]
    public IEnumerable<Workspace> Workspaces { get; set; } = null!;

    [SwaggerSchema("The workspace from the list of workspaces")]
    public sealed class Workspace
    {
        [SwaggerSchema("The workspace ID")]
        [SwaggerSchemaExample("1")]
        public int Id { get; set; }

        [SwaggerSchema("The workspace name")]
        [SwaggerSchemaExample("Some name")]
        public string Name { get; set; } = null!;
    }
}
