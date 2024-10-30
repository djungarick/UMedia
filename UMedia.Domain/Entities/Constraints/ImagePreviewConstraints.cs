namespace UMedia.Domain.Entities.Constraints;

// TODO: Move to WorkspaceAggregate.
public static class ImagePreviewConstraints
{
    public const int MaxWidth = 128;
    public const int MaxHeight = 128;

    public static readonly Result s_widthIsOutOfRangeResult = Result.Invalid(ImagePreviewErrors.WidthIsOutOfRange);
    public static readonly Result s_heightIsOutOfRangeResult = Result.Invalid(ImagePreviewErrors.HeightIsOutOfRange);

#pragma warning disable IDE0046 // Convert to conditional expression
    public static Result Check(int width, int height)
    {
        if (width > MaxWidth)
            return s_widthIsOutOfRangeResult;

        if (height > MaxHeight)
            return s_heightIsOutOfRangeResult;

        return CachedResults.Success;
    }
#pragma warning restore IDE0046 // Convert to conditional expression
}
