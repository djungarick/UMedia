using UMedia.Application.Workspaces;
using UMedia.Application.Workspaces.Queries.List;
using UMedia.WebAPI.Contract.V1_0.Workspace;

namespace UMedia.WebAPI.Controllers.V1_0;

[ApiController]
[ApiExplorerSettings(GroupName = GroupNameConstants.UMedia)]
[SwaggerTag("The workspace controller")]
[Route(RouteConstants.CommonController)]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
public sealed class WorkspaceController(IMediator mediator) : ControllerBase
{
    [TranslateResultToActionResult]
    [ExpectedFailures(ResultStatus.Invalid)]
    [SwaggerOperation("Get the list of workspaces")]
    public async Task<Result<GetWorkspaceListResponse>> GetListAsync([FromQuery] GetWorkspaceListRequest request)
    {
        Result<IEnumerable<WorkspaceDTO>> workspaceList = await mediator.Send(
            new ListWorkspacesQuery(request.Take, request.Skip));

        return workspaceList.Map(static _
            => new GetWorkspaceListResponse
            {
                Workspaces = _.Select(static _
                    => new GetWorkspaceListResponse.Workspace
                    {
                        Id = _.Id,
                        Name = _.Name
                    })
            });
    }
}
