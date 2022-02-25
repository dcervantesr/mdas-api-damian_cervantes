using Microsoft.Extensions.DependencyInjection;
using Pokemon.Pokemon.Domain;

namespace Pokemon.Pokemon.Infrastructure;

public static class DomainDependencyInjection
{
    public static IServiceCollection AddPokemonDomain(this IServiceCollection services)
    {
        services.AddTransient<PokemonFinder>();

        return services;
    }
}