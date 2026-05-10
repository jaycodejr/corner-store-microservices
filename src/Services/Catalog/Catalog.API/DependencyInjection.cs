using BuildingBlocks.CQRS;

namespace Catalog.API;

public static class DependencyInjection
{
    public static IServiceCollection AddCqrsHandlers(
    this IServiceCollection services)
    {
        // CQRS Dispatchers
        services.AddScoped<ICommandDispatcher, CommandDispatcher>();
        services.AddScoped<IQueryDispatcher, QueryDispatcher>();

        // Auto register ALL command handlers
        services.Scan(scan => scan
            .FromApplicationDependencies()
            .AddClasses(classes => classes
                .AssignableToAny(typeof(ICommandHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        // Auto register ALL query handlers
        services.Scan(scan => scan
            .FromApplicationDependencies()
            .AddClasses(classes => classes
                .AssignableToAny(typeof(IQueryHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}
