namespace UMedia.Application.Images.Commands.Create;

internal sealed class CreateImageCommandHandler(IRepository<Workspace> workspaceRepository,
    IImageUniqueNameQueryService imageUniqueNameQueryService)
    : ICommandHandler<CreateImageCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateImageCommand request, CancellationToken cancellationToken)
    {
        Workspace? workspace = await workspaceRepository.GetByIdAsync(request.WorkspaceId, cancellationToken);
        if (workspace is null)
            return CachedResults.NotFound;

        bool isNameAndWorkspaceIdUnique = await imageUniqueNameQueryService.CheckAsync(request.Name, request.WorkspaceId, cancellationToken);
        Result<Image> imageCreationResult = workspace.AddImage(request.Name, isNameAndWorkspaceIdUnique);

        if (imageCreationResult.IsSuccess)
            await workspaceRepository.UpdateAsync(workspace, cancellationToken);

        return imageCreationResult.Map(static _ => _.Id);
    }
}
