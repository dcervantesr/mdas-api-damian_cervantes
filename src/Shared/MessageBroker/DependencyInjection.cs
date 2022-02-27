using Microsoft.Extensions.DependencyInjection;

namespace Shared.MessageBroker;
public static class SharedDependencyInjection
{
    public static IServiceCollection AddShared(this IServiceCollection services)
    {
        services.AddSingleton<EventPublisher, RabbitMqEventPublisher>();
        return services;
    }
}
