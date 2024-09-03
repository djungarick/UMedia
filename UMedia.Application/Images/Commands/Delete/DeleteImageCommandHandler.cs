using UMedia.Domain.Entities.WorkspaceAggregate.Specifications;

namespace UMedia.Application.Images.Commands.Delete;

internal sealed class DeleteImageCommandHandler(IRepository<Workspace> workspaceRepository) : ICommandHandler<DeleteImageCommand, Result>
{
    public async Task<Result> Handle(DeleteImageCommand request, CancellationToken cancellationToken)
    {
        WorkspaceWithImageToDeleteSpecification workspaceWithImageToDeleteSpecification = new(request.Id);
        Workspace? workspace = await workspaceRepository.FirstOrDefaultAsync(workspaceWithImageToDeleteSpecification, cancellationToken);
        if (workspace is null)
            return CachedResults.NotFound;

        Result imageDeletionResult = workspace.DeleteImage(request.Id);

        if (imageDeletionResult.IsSuccess)
            await workspaceRepository.UpdateAsync(workspace, cancellationToken);

        return imageDeletionResult;
    }
}
