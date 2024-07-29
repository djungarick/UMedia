namespace UMedia.WebAPI.Contract.V1_0.Workspace;

public sealed class GetWorkspaceListRequest
{
    [SwaggerParameter("The amount of workspaces to skip")]
    [SwaggerSchemaExample(null)]
    public int? Skip { get; set; }

    [SwaggerParameter("The amount of workspaces to take")]
    [SwaggerSchemaExample(null)]
    public int? Take { get; set; }
}
