// Copied from https://andrewlock.net/adding-validation-to-strongly-typed-configuration-objects-using-flentvalidation/.

using UMedia.Domain.Other;

namespace UMedia.Domain.Extensions;

public static class FluentValidationExtensions
{
    public static OptionsBuilder<TOptions> ValidateFluentValidation<TOptions>(this OptionsBuilder<TOptions> optionsBuilder)
        where TOptions : class
    {
        _ = optionsBuilder.Services.AddSingleton<IValidateOptions<TOptions>>(
            provider => new FluentValidationOptions<TOptions>(optionsBuilder.Name, provider));

        return optionsBuilder;
    }

    public static OptionsBuilder<TOptions> AddOptionsWithValidation<TOptions>(this IServiceCollection services, string? configurationSection = null)
        where TOptions : class
        => services.AddOptions<TOptions>()
            .BindConfiguration(configurationSection ?? typeof(TOptions).Name)
            .ValidateFluentValidation()
            .ValidateOnStart();
}
