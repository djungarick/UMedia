namespace UMedia.Application.Images.Queries.List;

public sealed record ListImagesQuery(int WorkspaceId, int? Skip, int? Take) : IQuery<Result<IEnumerable<ImageDTO>>>;
