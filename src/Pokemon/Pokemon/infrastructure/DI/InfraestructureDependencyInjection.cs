using Microsoft.Extensions.DependencyInjection;
using Pokemon.Pokemon.Domain;

namespace Pokemon.Pokemon.Infrastructure;

public static class infrastructureDependencyInjection
{
    public static IServiceCollection AddPokemonInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IPokemonRepository, PokeApiPokemonRepository>();
        services.AddScoped<PokemonAdapter>();
        services.AddHostedService<NotifyPokemonAddAsFavoriteSubscriber>();
        services.AddMemoryCache();
        services.AddScoped<MemoryPokemonRepository>();
        return services;
    }
}