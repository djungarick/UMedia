// Copied from https://andrewlock.net/adding-validation-to-strongly-typed-configuration-objects-using-flentvalidation/.

namespace UMedia.Domain.Other;

public sealed class FluentValidationOptions<TOptions>(string? name, IServiceProvider serviceProvider)
    : IValidateOptions<TOptions> where TOptions : class
{
    public ValidateOptionsResult Validate(string? nameToValidate, TOptions options)
    {
        // Null name is used to configure all named options.
        if (name is not null && name != nameToValidate)
            // Ignored if not validating this instance.
            return ValidateOptionsResult.Skip;

        // Ensure options are provided to validate against.
        ArgumentNullException.ThrowIfNull(options);

        // Validators are typically registered as scoped,
        // so we need to create a scope to be safe, as this
        // method is be called from the root scope.
        using IServiceScope scope = serviceProvider.CreateScope();

        // Retrieve an instance of the validator.
        IValidator<TOptions> validator = scope.ServiceProvider.GetRequiredService<IValidator<TOptions>>();

        // Run the validation.
        ValidationResult results = validator.Validate(options);
        if (results.IsValid)
            // All good!
            return ValidateOptionsResult.Success;

        // Validation failed, so build the error message.
        string typeName = options.GetType().Name;

        return ValidateOptionsResult.Fail(
            [.. results.Errors.Select(_ => $"Fluent validation failed for '{typeName}.{_.PropertyName}' with the error: '{_.ErrorMessage}'.")]);
    }
}
