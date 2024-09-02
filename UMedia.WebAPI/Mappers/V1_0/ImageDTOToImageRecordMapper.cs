using UMedia.Application.Images;
using UMedia.WebAPI.Contract.V1_0.Image;

namespace UMedia.WebAPI.Mappers.V1_0;

internal sealed class ImageDTOToImageRecordMapper
{
    public static readonly Expression<Func<ImageDTO, ImageRecord>> Expression = static _ => new ImageRecord(_.Id, _.Name);

    public static readonly Func<ImageDTO, ImageRecord> Func = Expression.Compile();
}
