using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Processing;
using UMedia.Application.Models.Services.ImageFullAndImagePreviewCreator;
using UMedia.Domain.Entities.Constraints;

namespace UMedia.Application.Services;

internal sealed class ImageFullAndImagePreviewCreatorService : IImageFullAndImagePreviewCreatorService
{
    private static readonly Result s_imageFormatWasNotDecoded = Result.CriticalError("Unable to decode the image format.");
    private static readonly ResizeOptions s_imageFullToImagePreviewResizeOptions = new()
    {
        Mode = ResizeMode.Max,
        Sampler = KnownResamplers.Lanczos3,
        Size = new Size(ImagePreviewConstraints.MaxWidth, ImagePreviewConstraints.MaxHeight)
    };
    private static Result? s_imageFullCreatedButImagePreviewWasNotFilled;

    // TODO: Disable IDE0046 everywhere.
#pragma warning disable IDE0046 // Convert to conditional expression
    public Result<ImageFullAndImagePreview> Create(scoped ReadOnlySpan<byte> imageFullData)
    {
        scoped ReadOnlySpan<byte> imagePreviewData = null;
        bool hasImageFullValidContent = true;
        bool hasImageFullSupportedFormat = true;
        int? imageFullWidth = null;
        int? imageFullHeight = null;
        int? imagePreviewWidth = null;
        int? imagePreviewHeight = null;
        string? imageFullFormat = null;
        string? imagePreviewFormat = null;

        SixLaborsImage? sixLaborsImage = null;
        try
        {
            try
            {
                sixLaborsImage = SixLaborsImage.Load(imageFullData);
            }
            catch (InvalidImageContentException)
            {
                hasImageFullValidContent = false;
            }
            catch (UnknownImageFormatException)
            {
                hasImageFullSupportedFormat = false;
            }

            if (sixLaborsImage is not null)
            {
                imageFullWidth = sixLaborsImage.Width;
                imageFullHeight = sixLaborsImage.Height;

                IImageFormat? decodedImageFormat = sixLaborsImage.Metadata.DecodedImageFormat;
                if (decodedImageFormat is null)
                    return s_imageFormatWasNotDecoded;

                imageFullFormat = imagePreviewFormat = decodedImageFormat.Name;

                if (sixLaborsImage is { Width: <= ImagePreviewConstraints.MaxWidth, Height: <= ImagePreviewConstraints.MaxHeight })
                {
                    imagePreviewData = imageFullData;
                    imagePreviewWidth = sixLaborsImage.Width;
                    imagePreviewHeight = sixLaborsImage.Height;
                }
                else
                {
                    sixLaborsImage.Mutate(static _ => _.Resize(s_imageFullToImagePreviewResizeOptions));

                    using MemoryStream memoryStream = new();
                    sixLaborsImage.Save(memoryStream, decodedImageFormat);

                    imagePreviewData = memoryStream.ToArray();
                    imagePreviewWidth = ImagePreviewConstraints.MaxWidth;
                    imagePreviewHeight = ImagePreviewConstraints.MaxHeight;
                }
            }
        }
        finally
        {
            sixLaborsImage?.Dispose();
        }

        Result<ImageFull> imageFullCreationResult = ImageFull.Create(-1,
            imageFullData,
            imageFullWidth,
            imageFullHeight,
            imageFullFormat,
            hasImageFullValidContent,
            hasImageFullSupportedFormat);
        if (!imageFullCreationResult.IsSuccess)
            return imageFullCreationResult.MapNotImplemented<ImageFull, ImageFullAndImagePreview>();

        if (imagePreviewWidth is null || imagePreviewHeight is null || imagePreviewFormat is null || imagePreviewData == null)
        {
            return s_imageFullCreatedButImagePreviewWasNotFilled
                ??= Result.CriticalError($"Because of the image full was created successfully, '{nameof(imagePreviewWidth)}', '{nameof(imagePreviewHeight)}', '{nameof(imagePreviewFormat)}' and '{nameof(imagePreviewData)}' have not to be null.");
        }

        Result<ImagePreview> imagePreviewCreationResult = ImagePreview.Create(-1,
            imagePreviewData,
            imagePreviewWidth.Value,
            imagePreviewHeight.Value,
            imagePreviewFormat);
        if (!imagePreviewCreationResult.IsSuccess)
            return imagePreviewCreationResult.MapNotImplemented<ImagePreview, ImageFullAndImagePreview>();

        return new ImageFullAndImagePreview
        {
            ImageFull = imageFullCreationResult.Value,
            ImagePreview = imagePreviewCreationResult.Value
        };
    }
#pragma warning restore IDE0046 // Convert to conditional expression
}
