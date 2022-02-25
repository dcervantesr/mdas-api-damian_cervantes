using Microsoft.Extensions.DependencyInjection;
using Users.User.Domain;

namespace Users.User.Infrastructure;

public static class DomainDependencyInjection
{
    public static IServiceCollection AddDomains(this IServiceCollection services)
    {

        services.AddTransient<UserCreator>();
        services.AddTransient<UserAddPokemonFavorite>();

        return services;
    }
}