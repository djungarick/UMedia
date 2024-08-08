namespace UMedia.Application.Workspaces.Queries.List;

public sealed record ListWorkspacesQuery(int? Skip, int? Take) : IQuery<Result<IEnumerable<WorkspaceDTO>>>;
