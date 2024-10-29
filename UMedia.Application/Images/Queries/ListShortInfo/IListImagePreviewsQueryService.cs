namespace UMedia.Application.Images.Queries.ListShortInfo;

public interface IListImagePreviewsQueryService
{
    public Task<IEnumerable<ImagePreview>> ListReadOnlyAsync(IEnumerable<int> imageIds, CancellationToken cancellationToken = default);
}
