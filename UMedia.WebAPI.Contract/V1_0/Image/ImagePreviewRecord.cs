namespace UMedia.WebAPI.Contract.V1_0.Image;

[SwaggerSchema("The image preview")]
public sealed record ImagePreviewRecord([property: SwaggerSchema("The image preview width"), SwaggerSchemaExample("128")] int Width,
    [property: SwaggerSchema("The image preview height"), SwaggerSchemaExample("128")] int Height,
    [property: SwaggerSchema("The image preview format"), SwaggerSchemaExample("JPEG")] string Format,
    [property: SwaggerSchema("The image preview data")] IEnumerable<byte> Data);
