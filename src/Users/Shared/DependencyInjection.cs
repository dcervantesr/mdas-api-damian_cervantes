using Microsoft.Extensions.DependencyInjection;

namespace Users.Shared;
public static class SharedDependencyInjection
{
    public static IServiceCollection AddShared(this IServiceCollection services)
    {
        services.AddScoped<EventPublisher, RabbitMqEventPublisher>();
        return services;
    }
}
