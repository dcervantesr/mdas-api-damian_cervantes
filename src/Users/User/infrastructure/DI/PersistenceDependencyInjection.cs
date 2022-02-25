using Microsoft.Extensions.DependencyInjection;
using Users.User.Domain;

namespace Users.User.Infrastructure;

public static class PersistenceDependencyInjection
{
    public static IServiceCollection AddPersistences(this IServiceCollection services)
    {

        services.AddScoped<IUserRepository, InMemoryUserRepository>();
        services.AddSingleton<UserContext>();

        return services;
    }
}