using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace UMedia.WebAPI.ApplicationModelConventions;

internal sealed class HttpMethodFromActionNameApplicationModelConvention : IApplicationModelConvention
{
    private static readonly string[] s_httpVerbs = typeof(HttpMethod)
        .GetProperties()
        .Where(_ => _.PropertyType == typeof(HttpMethod))
        .Select(_ => ((HttpMethod)Guard.Against.Null(_.GetValue(null))).Method)
        .ToArray();

    public void Apply(ApplicationModel application)
    {
        foreach (ControllerModel controller in application.Controllers)
        {
            foreach (ActionModel action in controller.Actions)
            {
                for (int i = 0; i < s_httpVerbs.Length; i++)
                {
                    if (action.ActionName.StartsWith(s_httpVerbs[i], StringComparison.InvariantCultureIgnoreCase))
                    {
                        action.ActionName = action.ActionName[s_httpVerbs[i].Length..];

                        action.Selectors
                            .First()
                            .ActionConstraints
                            .Add(new HttpMethodActionConstraint([s_httpVerbs[i]]));

                        break;
                    }
                }
            }
        }
    }
}
