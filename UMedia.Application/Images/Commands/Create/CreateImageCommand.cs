namespace UMedia.Application.Images.Commands.Create;

public sealed record CreateImageCommand(int WorkspaceId, string Name, ImmutableArray<byte> Data) : ICommand<Result<int>>;
