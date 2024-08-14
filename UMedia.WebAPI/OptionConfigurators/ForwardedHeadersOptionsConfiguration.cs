using Microsoft.AspNetCore.HttpOverrides;

namespace UMedia.WebAPI.OptionConfigurators;

internal sealed class ForwardedHeadersOptionsConfiguration : IConfigureOptions<ForwardedHeadersOptions>
{
    public void Configure(ForwardedHeadersOptions options)
        => options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
}
