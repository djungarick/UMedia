namespace UMedia.Application.Images.Queries.List;

internal sealed class ListImagesQueryHandler(IListImagesQueryService listImagesQueryService) : IQueryHandler<ListImagesQuery, Result<IEnumerable<ImageDTO>>>
{
    public async Task<Result<IEnumerable<ImageDTO>>> Handle(ListImagesQuery request, CancellationToken cancellationToken)
        => await listImagesQueryService.ListReadOnlyAsync(request.WorkspaceId, request.Skip, request.Take, ImageToImageDTOMapper.Expression, cancellationToken);
}
