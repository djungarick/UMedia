using UMedia.Domain.Entities.WorkspaceAggregate.Specifications;

namespace UMedia.Application.Workspaces.Commands.Create;

internal sealed class CreateWorkspaceCommandHandler(IRepository<Workspace> workspaceRepository) : ICommandHandler<CreateWorkspaceCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateWorkspaceCommand request, CancellationToken cancellationToken)
    {
        WorkspaceIdByNameSpecification workspaceIdByNameSpecification = new(request.Name);
        int existingWorkspaceWithTheSameNameId = await workspaceRepository.FirstOrDefaultAsync(workspaceIdByNameSpecification, cancellationToken);

        Result<Workspace> workspaceCreationResult = Workspace.Create(request.Name, existingWorkspaceWithTheSameNameId == default);
        if (!workspaceCreationResult.IsSuccess)
            return workspaceCreationResult.Map(static _ => _.Id);

        Workspace createdWorkspace = await workspaceRepository.AddAsync(workspaceCreationResult.Value, cancellationToken);
        return createdWorkspace.Id;
    }
}
