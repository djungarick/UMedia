namespace UMedia.Application.Workspaces.Queries.Get;

internal sealed class GetWorkspaceQueryHandler(IReadRepository<Workspace> workspaceRepository) : IQueryHandler<GetWorkspaceQuery, Result<WorkspaceDTO>>
{
    public async Task<Result<WorkspaceDTO>> Handle(GetWorkspaceQuery request, CancellationToken cancellationToken)
    {
        Workspace? workspace = await workspaceRepository.GetByIdAsync(request.Id, cancellationToken);
        if (workspace is null)
            return CachedResults.NotFound;

        return WorkspaceToWorkspaceDTOMapper.Func(workspace);
    }
}
