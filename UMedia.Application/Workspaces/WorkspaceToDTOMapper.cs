namespace UMedia.Application.Workspaces;

public static class WorkspaceToDTOMapper
{
    public static readonly Expression<Func<Workspace, WorkspaceDTO>> Expression = static _ => new WorkspaceDTO(_.Id, _.Name);

    public static readonly Func<Workspace, WorkspaceDTO> Lambda = Expression.Compile();
}
