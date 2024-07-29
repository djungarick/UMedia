using UMedia.Persistence.Repositories;

namespace UMedia.Persistence.Extensions;

public static class LayerAddingExtensions
{
    public static IServiceCollection AddUMediaPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        => services.AddDbContext<UMediaDbContext>(options
            => options.UseNpgsql(
                Guard.Against.Null(
                    configuration.GetConnectionString(
                        nameof(UMediaDbContext))))
#if DEBUG
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging()
#endif
            )
            .AddScoped(typeof(IRepository<>), typeof(EfRepository<>))
            .AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
}
