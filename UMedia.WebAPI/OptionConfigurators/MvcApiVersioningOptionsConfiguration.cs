using Asp.Versioning.Conventions;

namespace UMedia.WebAPI.OptionConfigurators;

internal sealed class MvcApiVersioningOptionsConfiguration : IConfigureOptions<MvcApiVersioningOptions>
{
    public void Configure(MvcApiVersioningOptions options)
    {
        options.Conventions.Add(new VersionByNamespaceConvention());
    }
}
