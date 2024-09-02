using UMedia.Application.Images;
using UMedia.Application.Images.Queries.List;
using UMedia.WebAPI.Contract.V1_0.Image;
using UMedia.WebAPI.Mappers.V1_0;

namespace UMedia.WebAPI.Controllers.V1_0;

[ApiController]
[ApiExplorerSettings(GroupName = GroupNameConstants.UMedia)]
[SwaggerTag("The image controller")]
[Route(RouteConstants.CommonController)]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
public sealed class ImageController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [TranslateResultToActionResult]
    [ExpectedFailures(ResultStatus.Invalid, ResultStatus.NotFound, ResultStatus.CriticalError)]
    [SwaggerOperation("Get the list of images")]
    public async Task<Result<GetImageListResponse>> GetListAsync([FromQuery] GetImageListRequest request)
    {
        Result<IEnumerable<ImageDTO>> imageList = await mediator.Send(
            new ListImagesQuery(request.WorkspaceId, request.Skip, request.Take),
            HttpContext.RequestAborted);

        return imageList.Map(static _
            => new GetImageListResponse
            {
                Images = _.Select(ImageDTOToImageRecordMapper.Func)
            });
    }
}
