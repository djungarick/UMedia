using UMedia.Domain.Entities.WorkspaceAggregate.Specifications;

namespace UMedia.Application.Workspaces.Commands.Update;

internal sealed class UpdateWorkspaceCommandHandler(IRepository<Workspace> workspaceRepository) : ICommandHandler<UpdateWorkspaceCommand, Result<WorkspaceDTO>>
{
    public async Task<Result<WorkspaceDTO>> Handle(UpdateWorkspaceCommand request, CancellationToken cancellationToken)
    {
        Workspace? existingWorkspace = await workspaceRepository.GetByIdAsync(request.Id, cancellationToken);
        if (existingWorkspace is null)
            return CachedResults.NotFound;

        WorkspaceIdByNameSpecification workspaceIdByNameSpecification = new(request.Name);
        int workspaceWithSameNameId = await workspaceRepository.FirstOrDefaultAsync(workspaceIdByNameSpecification, cancellationToken);

        if (existingWorkspace.Name != request.Name)
        {
            Result updatingResult = existingWorkspace.UpdateName(request.Name, workspaceWithSameNameId == default);
            if (!updatingResult.IsSuccess)
                return updatingResult;

            await workspaceRepository.UpdateAsync(existingWorkspace, cancellationToken);
        }

        return Result.Success(WorkspaceToWorkspaceDTOMapper.Func(existingWorkspace));
    }
}
