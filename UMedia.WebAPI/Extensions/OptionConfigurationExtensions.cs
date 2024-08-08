using UMedia.WebAPI.OptionConfigurators;

namespace UMedia.WebAPI.Extensions;

internal static class OptionConfigurationExtensions
{
    private static readonly Type s_swaggerGenOptionsConfiguratorType = typeof(SwaggerGenOptionsConfigurator);
    private static readonly Type[] s_optionConfiguratorTypes = [typeof(IConfigureOptions<>), typeof(IConfigureNamedOptions<>)];

    public static IServiceCollection ApplyUMediaOptionConfigurations(this IServiceCollection services)
    {
        IEnumerable<Type> optionsToConfigure = s_swaggerGenOptionsConfiguratorType.Assembly
            .GetTypes()
            .Where(static _ => _.IsClass
                && _.Namespace == s_swaggerGenOptionsConfiguratorType.Namespace
                && Array.Exists(_.GetInterfaces(),
                    static i => i.IsGenericType
                        && s_optionConfiguratorTypes.Contains(i.GetGenericTypeDefinition())));

        foreach (Type optionToConfigure in optionsToConfigure)
            services.ConfigureOptions(optionToConfigure);

        return services;
    }
}
