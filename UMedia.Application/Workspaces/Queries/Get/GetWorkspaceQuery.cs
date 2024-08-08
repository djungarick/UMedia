namespace UMedia.Application.Workspaces.Queries.Get;

public sealed record GetWorkspaceQuery(int Id) : IQuery<Result<WorkspaceDTO>>;
