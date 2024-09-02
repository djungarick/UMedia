using UMedia.Application.Images.Queries.List;
using UMedia.Domain.Entities.WorkspaceAggregate;

namespace UMedia.Persistence.Queries.Images.List;

internal sealed class ListImagesQueryService(UMediaDbContext uMediaDbContext) : IListImagesQueryService
{
    public async Task<Result<IEnumerable<T>>> ListReadOnlyAsync<T>(int workspaceId,
        int? skip,
        int? take,
        Expression<Func<Image, T>> converter,
        CancellationToken cancellationToken)
    {
        List<T> result = await uMediaDbContext.Images
            .AsNoTracking()
            .Where(_ => _.WorkspaceId == workspaceId)
            .CustomSkip(skip)
            .CustomTake(take)
            .Select(converter)
            .ToListAsync(cancellationToken);

        return result.Count < 1 && !await uMediaDbContext.Workspaces.AnyAsync(_ => _.Id == workspaceId, cancellationToken)
            ? CachedResults.NotFound
            : result;
    }
}
