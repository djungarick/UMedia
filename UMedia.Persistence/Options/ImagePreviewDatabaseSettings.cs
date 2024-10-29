namespace UMedia.Persistence.Options;

public sealed class ImagePreviewDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string ImagePreviewsCollectionName { get; set; } = null!;

    public sealed class Validator : AbstractValidator<ImagePreviewDatabaseSettings>
    {
        public Validator()
        {
            _ = RuleFor(static _ => _.ConnectionString).NotEmpty();
            _ = RuleFor(static _ => _.DatabaseName).NotEmpty();
            _ = RuleFor(static _ => _.ImagePreviewsCollectionName).NotEmpty();
        }
    }
}
