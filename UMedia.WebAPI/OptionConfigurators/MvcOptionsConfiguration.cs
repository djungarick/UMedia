using UMedia.WebAPI.ApplicationModelConventions;

namespace UMedia.WebAPI.OptionConfigurators;

internal sealed class MvcOptionsConfiguration : IConfigureOptions<MvcOptions>
{
    public void Configure(MvcOptions options)
    {
        options.Conventions.Add(
            new HttpMethodFromActionNameApplicationModelConvention());

        options.AddResultConvention(resultStatusMap
            => resultStatusMap.AddDefaultMap()
                .For(ResultStatus.Ok, HttpStatusCode.OK, resultStatusOptions
                    => resultStatusOptions.For(HttpMethod.Post.Method, HttpStatusCode.Created)
                        .For(HttpMethod.Delete.Method, HttpStatusCode.NoContent))
                .For(ResultStatus.Error, HttpStatusCode.InternalServerError));
    }
}
