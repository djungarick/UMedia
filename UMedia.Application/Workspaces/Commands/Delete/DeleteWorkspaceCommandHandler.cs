namespace UMedia.Application.Workspaces.Commands.Delete;

internal sealed class DeleteWorkspaceCommandHandler(IRepository<Workspace> workspaceRepository) : ICommandHandler<DeleteWorkspaceCommand, Result>
{
    public async Task<Result> Handle(DeleteWorkspaceCommand request, CancellationToken cancellationToken)
    {
        Workspace? workspace = await workspaceRepository.GetByIdAsync(request.Id, cancellationToken);
        if (workspace is null)
            return CachedResults.NotFound;

        await workspaceRepository.DeleteAsync(workspace, cancellationToken);

        return CachedResults.Success;
    }
}
