using UMedia.Application.Images;
using UMedia.Application.Images.Commands.Create;
using UMedia.Application.Images.Commands.Delete;
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

    [HttpPost]
    [TranslateResultToActionResult]
    [ExpectedFailures(ResultStatus.Invalid, ResultStatus.NotFound, ResultStatus.CriticalError)]
    [SwaggerOperation("Create the image")]
    public async Task<Result<PostImageResponse>> PostAsync([FromQuery] PostImageRequest request)
    {
        Result<int> imageId = await mediator.Send(
            new CreateImageCommand(request.WorkspaceId, request.Name),
            HttpContext.RequestAborted);

        return imageId.Map(static _
            => new PostImageResponse
            {
                Id = _
            });
    }

    [HttpDelete]
    [TranslateResultToActionResult]
    [ExpectedFailures(ResultStatus.Invalid, ResultStatus.NotFound, ResultStatus.CriticalError)]
    [SwaggerOperation("Delete the image")]
    public async Task<Result> DeleteAsync([FromQuery] DeleteImageRequest request)
        => await mediator.Send(
            new DeleteImageCommand(request.Id),
            HttpContext.RequestAborted);
}
