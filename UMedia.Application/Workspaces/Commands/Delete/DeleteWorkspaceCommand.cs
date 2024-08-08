namespace UMedia.Application.Workspaces.Commands.Delete;

public sealed record DeleteWorkspaceCommand(int Id) : ICommand<Result>;
