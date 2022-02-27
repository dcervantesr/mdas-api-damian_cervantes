using Microsoft.Extensions.DependencyInjection;
using Pokemon.Pokemon.Domain;

namespace Pokemon.Pokemon.Infrastructure;

public static class infrastructureDependencyInjection
{
    public static IServiceCollection AddPokemonInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IPokemonRepository, PokeApiPokemonRepository>();
        services.AddSingleton<MemoryPokemonRepository>();
        services.AddScoped<PokemonAdapter>();
        services.AddScoped<NotifyPokemonAddAsFavoriteSubscriber>();
        return services;
    }
}