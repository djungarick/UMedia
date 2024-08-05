namespace UMedia.Application.Workspaces.Commands.Update;

/// <summary>
/// Update the workspace
/// </summary>
/// <param name="Id">The workspace id</param>
/// <param name="Name">The workspace new name</param>
public sealed record UpdateWorkspaceCommand(int Id, string Name) : ICommand<Result<WorkspaceDTO>>;
