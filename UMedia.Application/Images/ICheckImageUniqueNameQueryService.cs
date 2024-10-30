namespace UMedia.Application.Images;

public interface ICheckImageUniqueNameQueryService
{
    public Task<bool> CheckAsync(string name, int workspaceId, CancellationToken cancellationToken = default);
}
