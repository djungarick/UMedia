namespace UMedia.WebAPI.Contract.V1_0.Workspace;

public sealed class GetWorkspaceRequest
{
    [SwaggerParameter("The workspace ID")]
    [SwaggerSchemaExample("1")]
    public required int Id { get; set; }
}
