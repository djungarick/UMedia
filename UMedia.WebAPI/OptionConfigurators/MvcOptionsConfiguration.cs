using UMedia.WebAPI.ApplicationModelConventions;

namespace UMedia.WebAPI.OptionConfigurators;

internal sealed class MvcOptionsConfiguration : IConfigureOptions<MvcOptions>
{
    public void Configure(MvcOptions options)
    {
        options.Conventions.Add(
            new HttpMethodFromActionNameApplicationModelConvention());

        options.AddResultConvention(static resultStatusMap => resultStatusMap.AddDefaultMap());
    }
}
