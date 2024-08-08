using UMedia.Application.Workspaces;
using UMedia.WebAPI.Contract.V1_0.Workspace;

namespace UMedia.WebAPI.Mappers.V1_0;

internal static class WorkspaceDTOToWorkspaceRecordMapper
{
    public static readonly Expression<Func<WorkspaceDTO, WorkspaceRecord>> Expression = static _ => new WorkspaceRecord(_.Id, _.Name);

    public static readonly Func<WorkspaceDTO, WorkspaceRecord> Func = Expression.Compile();
}
