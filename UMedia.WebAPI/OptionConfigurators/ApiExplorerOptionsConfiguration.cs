using Asp.Versioning.ApiExplorer;

namespace UMedia.WebAPI.OptionConfigurators;

internal sealed class ApiExplorerOptionsConfiguration : IConfigureOptions<ApiExplorerOptions>
{
    public void Configure(ApiExplorerOptions options)
    {
        options.GroupNameFormat = VersioningConstants.DefaultVersionFormat;
        options.FormatGroupName = static (group, version) => $"{group}-{version}";

        options.SubstituteApiVersionInUrl = true;
        options.SubstitutionFormat = VersioningConstants.DefaultVersionFormatWithoutVLetter;
    }
}
