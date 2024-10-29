namespace UMedia.WebAPI.Contract.V1_0.Image;

[SwaggerSchema("The image")]
public sealed record ImageShortInfoRecord([property: SwaggerSchema("The image ID"), SwaggerSchemaExample("1")] int Id,
    [property: SwaggerSchema("The image name"), SwaggerSchemaExample("Some name")] string Name,
    [property: SwaggerSchema("The image preview info"), SwaggerSchemaExample(null)] ImagePreviewRecord? Preview);
