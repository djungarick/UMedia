namespace UMedia.Application.Images.Commands.Delete;

public sealed record DeleteImageCommand(int Id) : ICommand<Result>;
