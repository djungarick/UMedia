using Asp.Versioning.ApiExplorer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using UMedia.WebAPI.Swagger.OperationFilters;
using UMedia.WebAPI.Swagger.SchemaFilters;

namespace UMedia.WebAPI.OptionConfigurators;

internal sealed class SwaggerGenOptionsConfigurator(IApiVersionDescriptionProvider apiVersionDescriptionProvider) : IConfigureOptions<SwaggerGenOptions>
{
	public void Configure(SwaggerGenOptions options)
	{
		foreach (ApiVersionDescription apiVersionDescription in apiVersionDescriptionProvider.ApiVersionDescriptions)
		{
			options.SwaggerDoc(apiVersionDescription.GroupName,
				new OpenApiInfo
				{
					Title = "UMedia Project",
					Description = "UMedia Project WEB API",
					Version = apiVersionDescription.ApiVersion.ToString(VersioningConstants.DefaultVersionFormat)
				});
		}

		options.EnableAnnotations();
		options.SupportNonNullableReferenceTypes();

		// TODO: Check what it does.
		options.OperationFilter<SwaggerDefaultValuesOperationFilter>();

		options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
		options.OperationFilter<SecurityRequirementsOperationFilter>();

		options.SchemaFilter<SwaggerSchemaExampleFilter>();
	}
}
