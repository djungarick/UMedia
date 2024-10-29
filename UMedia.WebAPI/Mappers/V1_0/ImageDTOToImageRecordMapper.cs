using UMedia.Application.Images;
using UMedia.WebAPI.Contract.V1_0.Image;

namespace UMedia.WebAPI.Mappers.V1_0;

internal sealed class ImageDTOToImageRecordMapper
{
    public static readonly Expression<Func<ImageShortInfoDTO, ImageShortInfoRecord>> Expression = static _
        => new ImageShortInfoRecord(_.Id,
            _.Name,
            _.Preview == null
                ? null
                : new ImagePreviewRecord(_.Preview.Width, _.Preview.Height, _.Preview.Format, _.Preview.Data));

    public static readonly Func<ImageShortInfoDTO, ImageShortInfoRecord> Func = Expression.Compile();
}
