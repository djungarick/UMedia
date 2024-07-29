namespace UMedia.WebAPI.Constants;

internal static class RouteConstants
{
    public const string RoutePrefix = "umedia";
    public const string CommonController = $$"""{{RoutePrefix}}/api/v{version:apiVersion}/[controller]/[action]""";
}
