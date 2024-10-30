namespace UMedia.Persistence.Extensions;

internal static class QueryableExtensions
{
    public static IQueryable<T> CustomSkip<T>(this IQueryable<T> queryable, int? skip)
        => skip.HasValue ? queryable.Skip(skip.Value) : queryable;

    public static IQueryable<T> CustomTake<T>(this IQueryable<T> queryable, int? take)
        => take.HasValue ? queryable.Take(take.Value) : queryable;
}
