namespace UMedia.Domain.Entities.Constraints;

public static class CommonNameConstraints
{
    public const int MinimumLength = 1;
    public const int MaximumLength = 200;

    private static readonly Result s_isNotUniqueResult = Result.Invalid(CommonNameErrors.IsNotUnique);
    private static readonly Result s_isNullOrEmptyResult = Result.Invalid(CommonNameErrors.IsNullOrEmpty);
    private static readonly Result s_startsWithWhiteSpaceResult = Result.Invalid(CommonNameErrors.StartsWithWhiteSpace);
    private static readonly Result s_LengthIsOutOfRangeResult = Result.Invalid(CommonNameErrors.LengthIsOutOfRange);

    public static Result Check(string? name, bool isNameUnique)
    {
        if (!isNameUnique)
            return s_isNotUniqueResult;

        if (string.IsNullOrEmpty(name))
            return s_isNullOrEmptyResult;

        if (char.IsWhiteSpace(name, 0))
            return s_startsWithWhiteSpaceResult;

        if (name.Length is < MinimumLength or > MaximumLength)
            return s_LengthIsOutOfRangeResult;

        return CachedResults.Success;
    }
}
