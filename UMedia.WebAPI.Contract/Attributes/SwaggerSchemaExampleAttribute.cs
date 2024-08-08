namespace UMedia.WebAPI.Contract.Attributes;

[AttributeUsage(AttributeTargets.Class
    | AttributeTargets.Struct
    | AttributeTargets.Parameter
    | AttributeTargets.Property
    | AttributeTargets.Enum,
    AllowMultiple = false)]
public sealed class SwaggerSchemaExampleAttribute(string? example) : Attribute
{
    public string? Example { get; } = example;
}
