using UMedia.Application.Images;
using UMedia.Application.Images.Commands.Create;
using UMedia.Application.Images.Commands.Delete;
using UMedia.Application.Images.Queries.ListShortInfo;
using UMedia.Persistence.BsonClassMaps;
using UMedia.Persistence.Queries.Images;
using UMedia.Persistence.Queries.Images.Commands.Create;
using UMedia.Persistence.Queries.Images.Commands.Delete;
using UMedia.Persistence.Queries.Images.Queries.List;
using UMedia.Persistence.Repositories;

namespace UMedia.Persistence.Extensions;

public static class LayerAddingExtensions
{
    public static IServiceCollection AddUMediaPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        => services.AddUMediaPersistenceLayerDbContexts(configuration)
            .AddUMediaPersistenceLayerRepositories()
            .AddUMediaPersistenceLayerQueryServices()
            .AddUMediaPersistenceLayerValidators()
            .AddUMediaPersistenceLayerOptions()
            .AddUMediaPersistenceLayerMongoDbClassMaps();

    public static IServiceCollection AddUMediaPersistenceLayerDbContexts(this IServiceCollection services, IConfiguration configuration)
        => services.AddDbContext<UMediaDbContext>(options
            => options.UseNpgsql(
                Guard.Against.Null(
                    configuration.GetConnectionString(
                        nameof(UMediaDbContext))))
#if DEBUG
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging()
#endif
            );

    public static IServiceCollection AddUMediaPersistenceLayerRepositories(this IServiceCollection services)
        => services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>))
            .AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));

    public static IServiceCollection AddUMediaPersistenceLayerQueryServices(this IServiceCollection services)
        => services.AddScoped<IListImagesQueryService, ListImagesQueryService>()
            .AddScoped<IListImagePreviewsQueryService, ListImagePreviewsQueryService>()
            .AddScoped<ICheckImageUniqueNameQueryService, CheckImageUniqueNameQueryService>()
            .AddScoped<ICreateImageFullQueryService, CreateImageFullQueryService>()
            .AddScoped<ICreateImagePreviewQueryService, CreateImagePreviewQueryService>()
            .AddScoped<IDeleteImageFullQueryService, DeleteImageFullQueryService>()
            .AddScoped<IDeleteImagePreviewQueryService, DeleteImagePreviewQueryService>();

    public static IServiceCollection AddUMediaPersistenceLayerValidators(this IServiceCollection services)
        => services.AddValidatorsFromAssemblyContaining<ImagePreviewDatabaseSettings.Validator>();

    public static IServiceCollection AddUMediaPersistenceLayerOptions(this IServiceCollection services)
    {
        _ = services.AddOptionsWithValidation<ImagePreviewDatabaseSettings>();

        return services;
    }

    public static IServiceCollection AddUMediaPersistenceLayerMongoDbClassMaps(this IServiceCollection services)
    {
        Type imagePreviewBsonClassMapType = typeof(ImagePreviewBsonClassMap);

        IEnumerable<Type> bsonClassMaps = imagePreviewBsonClassMapType.Assembly
            .GetTypes()
            .Where(_ => _.IsClass
                && _.IsAbstract
                && _.IsSealed
                && _.Namespace == imagePreviewBsonClassMapType.Namespace);

        string registerMethodName = nameof(ImagePreviewBsonClassMap.Register);

        foreach (Type bsonClassMap in bsonClassMaps)
        {
            MethodInfo? registerMethodInfo = bsonClassMap.GetMethod(registerMethodName, BindingFlags.Public | BindingFlags.Static)
                ?? throw new NullReferenceException($"The {bsonClassMap.FullName} class does not contain the public static {registerMethodName} method.");

            _ = registerMethodInfo.Invoke(null, null);
        }

        return services;
    }
}
