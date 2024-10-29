namespace UMedia.Application.Images.Commands.Create;

// TODO: Move all to UseCases.
public interface ICreateImageFullQueryService
{
    public Task CreateAsync(ImageFull imageFull, CancellationToken cancellationToken = default);
}
