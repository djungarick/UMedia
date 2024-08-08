namespace UMedia.Application.Workspaces.Commands.Create;

/// <summary>
/// Create a new workspace.
/// </summary>
/// <param name="Name">The new workspace name</param>
public sealed record CreateWorkspaceCommand(string Name) : ICommand<Result<int>>;
