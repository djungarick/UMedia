namespace UMedia.Application.Images.Commands.Create;

public sealed record CreateImageCommand(int WorkspaceId, string Name) : ICommand<Result<int>>;
