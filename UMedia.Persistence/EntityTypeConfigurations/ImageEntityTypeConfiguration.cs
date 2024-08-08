using UMedia.Domain.Entities.WorkspaceAggregate;

namespace UMedia.Persistence.EntityTypeConfigurations;

internal sealed class ImageEntityTypeConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.Property(static _ => _.Id)
            .UseSerialColumn();

        builder.HasIndex(static _ => _.Name)
            .IsUnique();

        builder.Property(static _ => _.Name)
            .HasMaxLength(CommonNameConstraints.MaximumLength);
    }
}
