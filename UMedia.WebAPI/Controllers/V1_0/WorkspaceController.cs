using UMedia.WebAPI.Contract.V1_0.Workspace;

namespace UMedia.WebAPI.Controllers.V1_0;

[ApiController]
[ApiExplorerSettings(GroupName = GroupNameConstants.UMedia)]
[SwaggerTag("The workspace controller")]
[Route(RouteConstants.CommonController)]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
public sealed class WorkspaceController : ControllerBase
{
    [TranslateResultToActionResult]
    [ExpectedFailures(ResultStatus.Invalid)]
    [SwaggerOperation("Get the list of workspaces")]
    public async Task<Result<GetWorkspaceListResponse>> GetListAsync([FromQuery] GetWorkspaceListRequest request)
    {
        return Result<GetWorkspaceListResponse>.Invalid(
            new ValidationError
            {
                ErrorMessage = "Test",
                ErrorCode = "Test2",
                Identifier = "Test3"
            });
        //return Result<GetWorkspaceListResponse>.Success(
        //    new GetWorkspaceListResponse
        //    {
        //        Workspaces =
        //        [
        //            new GetWorkspaceListResponse.Workspace
        //            {
        //                Id = 10,
        //                Name = "Test",
        //            }
        //        ]
        //    });
    }
}
