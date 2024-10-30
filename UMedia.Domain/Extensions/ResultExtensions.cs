namespace UMedia.Domain.Extensions;

public static class ResultExtensions
{
    public static Result<TDestination> MapNotImplemented<TSource, TDestination>(this Result<TSource> result)
        => result.Map<TSource, TDestination>(static _ => throw new NotImplementedException());
}
