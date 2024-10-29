namespace UMedia.Application.Images.Queries.ListShortInfo;

public interface IListImagesQueryService
{
    public Task<Result<IEnumerable<Image>>> ListReadOnlyAsync(int workspaceId,
        int? skip,
        int? take,
        CancellationToken cancellationToken = default);
}
