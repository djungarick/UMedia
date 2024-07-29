namespace UMedia.WebAPI.OptionConfigurators;

internal sealed class ApiVersioningOptionsConfiguration : IConfigureOptions<ApiVersioningOptions>
{
    public void Configure(ApiVersioningOptions options)
    {
        options.ApiVersionReader = new UrlSegmentApiVersionReader();

        options.AssumeDefaultVersionWhenUnspecified = true;
        options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);
    }
}
