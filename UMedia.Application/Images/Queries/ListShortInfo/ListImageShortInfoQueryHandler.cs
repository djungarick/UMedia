namespace UMedia.Application.Images.Queries.ListShortInfo;

internal sealed class ListImageShortInfoQueryHandler(IListImagesQueryService listImagesQueryService,
    IListImagePreviewsQueryService listImagePreviewsQueryService,
    ILogger<ListImageShortInfoQueryHandler> logger)
    : IQueryHandler<ListImageShortInfoQuery, Result<IEnumerable<ImageShortInfoDTO>>>
{
    public async Task<Result<IEnumerable<ImageShortInfoDTO>>> Handle(ListImageShortInfoQuery request, CancellationToken cancellationToken)
    {
        Result<IEnumerable<Image>> listImagesResult = await listImagesQueryService.ListReadOnlyAsync(request.WorkspaceId,
            request.Skip,
            request.Take,
            cancellationToken);
        if (!listImagesResult.IsSuccess)
            return listImagesResult.MapNotImplemented<IEnumerable<Image>, IEnumerable<ImageShortInfoDTO>>();

        IEnumerable<Image> images = listImagesResult.Value;
        IEnumerable<ImagePreview> imagePreviews = await listImagePreviewsQueryService.ListReadOnlyAsync(images.Select(static _ => _.Id),
            cancellationToken);

        return Result.Success(
            images.GroupJoin(imagePreviews,
                static _ => _.Id,
                static _ => _.ImageId,
                (image, imagePreviews) =>
                {
                    int imagePreviewCount = imagePreviews.Count();

                    if (imagePreviewCount > 1)
                    {
                        logger.LogWarning("The image with the '{ImageId}' ID has more than one preview ({PreviewCount}).",
                            image.Id,
                            imagePreviewCount);
                    }
                    else if (imagePreviewCount < 1)
                    {
                        logger.LogWarning("The image with the '{ImageId}' ID has no previews.", image.Id);
                    }

                    return ImageAndImagePreviewToImagePreviewDTOMapper.Func(image, imagePreviews.FirstOrDefault());
                }));
    }
}
