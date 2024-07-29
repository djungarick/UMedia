using UMedia.Domain.Entities.WorkspaceAggregate.Specifications;

namespace UMedia.Application.Workspaces.Queries.List;

internal sealed class ListWorkspacesQueryHandler(IReadRepository<Workspace> workspaceRepository) : IQueryHandler<ListWorkspacesQuery, Result<IEnumerable<WorkspaceDTO>>>
{
    public async Task<Result<IEnumerable<WorkspaceDTO>>> Handle(ListWorkspacesQuery request, CancellationToken cancellationToken)
    {
        ListWorkspaceSpecification<WorkspaceDTO> listWorkspaceSpecification = new(request.Skip,
            request.Take,
            WorkspaceToDTOMapper.Expression);
        IEnumerable<WorkspaceDTO> workspaces = await workspaceRepository.ListAsync(listWorkspaceSpecification, cancellationToken);

        return Result.Success(workspaces);
    }
}
