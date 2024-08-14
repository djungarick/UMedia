using UMedia.Domain.Entities.WorkspaceAggregate;

namespace UMedia.Persistence.EntityTypeConfigurations;

internal sealed class WorkspaceEntityTypeConfiguration : IEntityTypeConfiguration<Workspace>
{
    public void Configure(EntityTypeBuilder<Workspace> builder)
    {
        _ = builder.Property(static _ => _.Id)
            .UseSerialColumn();

        _ = builder.HasIndex(static _ => _.Name)
            .IsUnique();

        _ = builder.Property(static _ => _.Name)
            .HasMaxLength(CommonNameConstraints.MaximumLength);
    }
}
