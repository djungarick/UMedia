using UMedia.Application.Images.Queries.ListShortInfo;
using UMedia.Domain.Entities.WorkspaceAggregate;

namespace UMedia.Persistence.Queries.Images.Queries.List;

internal sealed class ListImagesQueryService(UMediaDbContext uMediaDbContext) : IListImagesQueryService
{
    public async Task<Result<IEnumerable<Image>>> ListReadOnlyAsync(int workspaceId,
        int? skip,
        int? take,
        CancellationToken cancellationToken)
    {
        List<Image> result = await uMediaDbContext.Images
            .AsNoTracking()
            .Where(_ => _.WorkspaceId == workspaceId)
            .CustomSkip(skip)
            .CustomTake(take)
            .ToListAsync(cancellationToken);

        return result.Count < 1 && !await uMediaDbContext.Workspaces.AnyAsync(_ => _.Id == workspaceId, cancellationToken)
            ? CachedResults.NotFound
            : result;
    }
}
