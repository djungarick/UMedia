using UMedia.Application.Models.Services.ImageFullAndImagePreviewCreator;

namespace UMedia.Application.Images.Commands.Create;

internal sealed class CreateImageCommandHandler(IRepository<Workspace> workspaceRepository,
    ICheckImageUniqueNameQueryService imageUniqueNameQueryService,
    ICreateImageFullQueryService createImageFullQueryService,
    ICreateImagePreviewQueryService createImagePreviewQueryService,
    IImageFullAndImagePreviewCreatorService imageFullAndImagePreviewCreatorService)
    : ICommandHandler<CreateImageCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateImageCommand request, CancellationToken cancellationToken)
    {
        Result<ImageFullAndImagePreview> imageFullAndImagePreviewCreationResult = imageFullAndImagePreviewCreatorService.Create(request.Data.AsSpan());
        if (!imageFullAndImagePreviewCreationResult.IsSuccess)
            return imageFullAndImagePreviewCreationResult.MapNotImplemented<ImageFullAndImagePreview, int>();

        Workspace? workspace = await workspaceRepository.GetByIdAsync(request.WorkspaceId, cancellationToken);
        if (workspace is null)
            return CachedResults.NotFound;

        bool isNameAndWorkspaceIdUnique = await imageUniqueNameQueryService.CheckAsync(request.Name, request.WorkspaceId, cancellationToken);
        Result<Image> imageCreationResult = workspace.AddImage(request.Name, isNameAndWorkspaceIdUnique);
        if (!imageCreationResult.IsSuccess)
            return imageCreationResult.MapNotImplemented<Image, int>();

        // TODO: Add a transaction.
        await workspaceRepository.UpdateAsync(workspace, cancellationToken);

        int createdImageId = imageCreationResult.Value.Id;
        (ImageFull imageFull, ImagePreview imagePreview) = imageFullAndImagePreviewCreationResult.Value;

        imageFull.UpdateImageId(createdImageId);
        imagePreview.UpdateImageId(createdImageId);

        await createImageFullQueryService.CreateAsync(imageFull, cancellationToken);
        await createImagePreviewQueryService.CreateAsync(imagePreview, cancellationToken);

        return createdImageId;
    }
}
