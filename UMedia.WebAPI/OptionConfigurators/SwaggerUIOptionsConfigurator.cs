using Asp.Versioning.ApiExplorer;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace UMedia.WebAPI.OptionConfigurators;

internal sealed class SwaggerUIOptionsConfigurator(IApiVersionDescriptionProvider apiVersionDescriptionProvider) : IConfigureOptions<SwaggerUIOptions>
{
    public void Configure(SwaggerUIOptions options)
    {
        foreach (ApiVersionDescription apiVersionDescription in apiVersionDescriptionProvider.ApiVersionDescriptions)
            options.SwaggerEndpoint($"{apiVersionDescription.GroupName}/swagger.json", apiVersionDescription.GroupName);

        options.RoutePrefix = $"{RouteConstants.RoutePrefix}/swagger";
    }
}
