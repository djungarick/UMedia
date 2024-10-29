namespace UMedia.Domain.Entities.Constraints;

public static class ImageFullConstraints
{
    private static readonly Result s_isNotValidContentResult = Result.Invalid(ImageFullErrors.IsNotValidContent);
    private static readonly Result s_isNotSupportedFormatResult = Result.Invalid(ImageFullErrors.IsNotSupportedFormat);

#pragma warning disable IDE0046 // Convert to conditional expression
    public static Result Check(bool isValidContent, bool isSupportedFormat)
    {
        if (!isValidContent)
            return s_isNotValidContentResult;

        if (!isSupportedFormat)
            return s_isNotSupportedFormatResult;

        return CachedResults.Success;
    }
#pragma warning restore IDE0046 // Convert to conditional expression
}
