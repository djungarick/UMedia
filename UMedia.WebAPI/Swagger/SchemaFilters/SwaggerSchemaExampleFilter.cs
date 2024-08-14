using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using UMedia.WebAPI.Contract.Attributes;

namespace UMedia.WebAPI.Swagger.SchemaFilters;

internal sealed class SwaggerSchemaExampleFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        SwaggerSchemaExampleAttribute? swaggerSchemaExampleAttribute = context.MemberInfo
            ?.GetCustomAttributes<SwaggerSchemaExampleAttribute>()
            .FirstOrDefault();

        if (swaggerSchemaExampleAttribute is not null)
        {
            schema.Example = swaggerSchemaExampleAttribute.Example is null
                ? new OpenApiNull()
                : new OpenApiString(swaggerSchemaExampleAttribute.Example);
        }
    }
}
