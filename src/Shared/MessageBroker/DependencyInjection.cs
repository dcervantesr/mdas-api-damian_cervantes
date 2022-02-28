using Microsoft.Extensions.DependencyInjection;

namespace Shared.MessageBroker;
public static class SharedDependencyInjection
{
    public static IServiceCollection AddShared(this IServiceCollection services)
    {
        services.AddSingleton(sp => RabbitHutch.CreateBus("amqp://netcoders:netcoders@rabbitmq:5672/netcoders"));
        return services;
    }
}
