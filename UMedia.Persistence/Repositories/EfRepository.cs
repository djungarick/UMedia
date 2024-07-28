using Ardalis.Specification.EntityFrameworkCore;

namespace UMedia.Persistence.Repositories;

internal sealed class EfRepository<T>(UMediaDbContext uMediaDbContext) : RepositoryBase<T>(uMediaDbContext), IReadRepository<T>, IRepository<T>
    where T : class, IAggregateRoot
{
}
