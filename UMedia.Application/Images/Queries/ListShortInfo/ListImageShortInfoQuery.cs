namespace UMedia.Application.Images.Queries.ListShortInfo;

public sealed record ListImageShortInfoQuery(int WorkspaceId, int? Skip, int? Take) : IQuery<Result<IEnumerable<ImageShortInfoDTO>>>;
