using Microsoft.Extensions.DependencyInjection;
using UMedia.Application.Workspaces.Queries.List;

namespace UMedia.Application.Extensions;

public static class LayerAddingExtensions
{
    private static readonly Assembly[] s_mediatRAssemblies = [typeof(Workspace).Assembly, typeof(ListWorkspacesQuery).Assembly];

    public static IServiceCollection AddUMediaApplicationLayer(this IServiceCollection services)
        => services.AddMediatR(static _ => _.RegisterServicesFromAssemblies(s_mediatRAssemblies))
            .AddScoped<IDomainEventDispatcher, MediatRDomainEventDispatcher>();
}
