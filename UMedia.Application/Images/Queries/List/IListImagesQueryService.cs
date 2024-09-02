namespace UMedia.Application.Images.Queries.List;

public interface IListImagesQueryService
{
    public Task<Result<IEnumerable<T>>> ListReadOnlyAsync<T>(int workspaceId,
        int? skip,
        int? take,
        Expression<Func<Image, T>> converter,
        CancellationToken cancellationToken = default);
}
