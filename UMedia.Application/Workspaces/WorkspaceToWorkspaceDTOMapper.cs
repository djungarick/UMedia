namespace UMedia.Application.Workspaces;

public static class WorkspaceToWorkspaceDTOMapper
{
    public static readonly Expression<Func<Workspace, WorkspaceDTO>> Expression = static _ => new WorkspaceDTO(_.Id, _.Name);

    public static readonly Func<Workspace, WorkspaceDTO> Func = Expression.Compile();
}
