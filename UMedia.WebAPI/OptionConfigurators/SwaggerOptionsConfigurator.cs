using Swashbuckle.AspNetCore.Swagger;

namespace UMedia.WebAPI.OptionConfigurators;

internal sealed class SwaggerOptionsConfigurator : IConfigureOptions<SwaggerOptions>
{
    public void Configure(SwaggerOptions options)
    {
        options.RouteTemplate = $$"""{{RouteConstants.RoutePrefix}}/swagger/{documentName}/swagger.json""";
    }
}
