using UMedia.Application.Images;

namespace UMedia.Persistence.Queries.Images;

internal sealed class CheckImageUniqueNameQueryService(UMediaDbContext uMediaDbContext) : ICheckImageUniqueNameQueryService
{
    public async Task<bool> CheckAsync(string name, int workspaceId, CancellationToken cancellationToken)
        => !await uMediaDbContext.Images.AnyAsync(_ => _.Name == name && _.WorkspaceId == workspaceId, cancellationToken);
}
