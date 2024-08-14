using UMedia.Domain.Entities.WorkspaceAggregate;
using UMedia.Persistence.EntityTypeConfigurations;

namespace UMedia.Persistence.DbContexts;

internal sealed class UMediaDbContext(DbContextOptions<UMediaDbContext> options, IDomainEventDispatcher? domainEventDispatcher) : DbContext(options)
{
    public DbSet<Workspace> Workspaces => Set<Workspace>();

    public DbSet<Image> Images => Set<Image>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(WorkspaceEntityTypeConfiguration).Assembly);

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        int result = await base.SaveChangesAsync(cancellationToken)
            .ConfigureAwait(false);

        if (domainEventDispatcher is null)
            return result;

        EntityBase[] entitiesWithEvents = ChangeTracker.Entries<EntityBase>()
            .Select(static _ => _.Entity)
            .Where(static _ => _.DomainEvents.Any())
            .ToArray();

        await domainEventDispatcher.DispatchAndClearEvents(entitiesWithEvents);

        return result;
    }

    public override int SaveChanges()
        => SaveChangesAsync()
            .GetAwaiter()
            .GetResult();
}
