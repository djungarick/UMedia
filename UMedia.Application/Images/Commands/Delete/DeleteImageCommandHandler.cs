using UMedia.Domain.Entities.WorkspaceAggregate.Specifications;

namespace UMedia.Application.Images.Commands.Delete;

internal sealed class DeleteImageCommandHandler(IRepository<Workspace> workspaceRepository,
    IDeleteImageFullQueryService deleteImageFullQueryService,
    IDeleteImagePreviewQueryService deleteImagePreviewQueryService,
    ILogger<DeleteImageCommandHandler> logger)
    : ICommandHandler<DeleteImageCommand, Result>
{
    public async Task<Result> Handle(DeleteImageCommand request, CancellationToken cancellationToken)
    {
        WorkspaceWithImageToDeleteSpecification workspaceWithImageToDeleteSpecification = new(request.Id);
        Workspace? workspace = await workspaceRepository.FirstOrDefaultAsync(workspaceWithImageToDeleteSpecification, cancellationToken);
        if (workspace is null)
            return CachedResults.NotFound;

        Image? image = workspace.Images.FirstOrDefault(_ => _.Id == request.Id);
        if (image is null)
            return CachedResults.NotFound;

        Result imageDeletionResult = workspace.DeleteImage(request.Id);
        if (!imageDeletionResult.IsSuccess)
            return imageDeletionResult;

        // TODO: Add a transaction.
        await workspaceRepository.UpdateAsync(workspace, cancellationToken);

        long deletedPreviewCount = await deleteImageFullQueryService.DeleteAsync(request.Id, cancellationToken);
        if (deletedPreviewCount < 1)
            logger.LogWarning("No image preview was deleted for the image with the '{ImageId}' ID.", image.Id);

        long deletedFullCount = await deleteImagePreviewQueryService.DeleteAsync(request.Id, cancellationToken);
        if (deletedFullCount < 1)
            logger.LogWarning("No image full was deleted for the image with the '{ImageId}' ID.", image.Id);

        return imageDeletionResult;
    }
}
