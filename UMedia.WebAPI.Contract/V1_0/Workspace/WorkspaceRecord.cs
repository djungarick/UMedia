namespace UMedia.WebAPI.Contract.V1_0.Workspace;

[SwaggerSchema("The workspace from the list of workspaces")]
public sealed record WorkspaceRecord([property: SwaggerSchema("The workspace ID"), SwaggerSchemaExample("1")] int Id,
    [property: SwaggerSchema("The workspace name"), SwaggerSchemaExample("Some name")] string Name);
