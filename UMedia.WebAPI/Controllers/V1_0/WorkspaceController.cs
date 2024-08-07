using UMedia.Application.Workspaces;
using UMedia.Application.Workspaces.Commands.Create;
using UMedia.Application.Workspaces.Commands.Delete;
using UMedia.Application.Workspaces.Commands.Update;
using UMedia.Application.Workspaces.Queries.List;
using UMedia.WebAPI.Contract.V1_0.Workspace;
using UMedia.WebAPI.Mappers.V1_0;

namespace UMedia.WebAPI.Controllers.V1_0;

[ApiController]
[ApiExplorerSettings(GroupName = GroupNameConstants.UMedia)]
[SwaggerTag("The workspace controller")]
[Route(RouteConstants.CommonController)]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
public sealed class WorkspaceController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [TranslateResultToActionResult]
    [ExpectedFailures(ResultStatus.Invalid, ResultStatus.CriticalError)]
    [SwaggerOperation("Get the list of workspaces")]
    public async Task<Result<GetWorkspaceListResponse>> GetListAsync([FromQuery] GetWorkspaceListRequest request)
    {
        Result<IEnumerable<WorkspaceDTO>> workspaceList = await mediator.Send(
            new ListWorkspacesQuery(request.Take, request.Skip),
            HttpContext.RequestAborted);

        return workspaceList.Map(static _
            => new GetWorkspaceListResponse
            {
                Workspaces = _.Select(WorkspaceDTOToWorkspaceRecordMapper.Func)
            });
    }

    [HttpPost]
    [TranslateResultToActionResult]
    [ExpectedFailures(ResultStatus.Invalid, ResultStatus.CriticalError)]
    [SwaggerOperation("Create the workspace")]
    public async Task<Result<PostWorkspaceResponse>> PostWorkspaceAsync([FromBody] PostWorkspaceRequest request)
    {
        Result<int> workspaceId = await mediator.Send(
            new CreateWorkspaceCommand(request.Name),
            HttpContext.RequestAborted);

        return workspaceId.Map(_
            => new PostWorkspaceResponse
            {
                Id = workspaceId.Value
            });
    }

    [HttpPut]
    [TranslateResultToActionResult]
    [ExpectedFailures(ResultStatus.Invalid, ResultStatus.NotFound, ResultStatus.CriticalError)]
    [SwaggerOperation("Update the workspace")]
    public async Task<Result<PutWorkspaceResponse>> PutWorkspaceAsync([FromQuery] int id, [FromBody] PutWorkspaceRequest request)
    {
        Result<WorkspaceDTO> workspace = await mediator.Send(
            new UpdateWorkspaceCommand(id, request.Name),
            HttpContext.RequestAborted);

        return workspace.Map(static _
            => new PutWorkspaceResponse
            {
                Workspace = WorkspaceDTOToWorkspaceRecordMapper.Func(_)
            });
    }

    [HttpDelete]
    [TranslateResultToActionResult]
    [ExpectedFailures(ResultStatus.NotFound, ResultStatus.CriticalError)]
    [SwaggerOperation("Delete the workspace")]
    public async Task<Result> DeleteWorkspaceAsync([FromQuery] DeleteWorkspaceRequest request)
        => await mediator.Send(
            new DeleteWorkspaceCommand(request.Id),
            HttpContext.RequestAborted);
}
