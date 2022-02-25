using Microsoft.Extensions.DependencyInjection;
using Pokemon.Pokemon.Domain;

namespace Pokemon.Pokemon.Infrastructure;

public static class infrastructureDependencyInjection
{
    public static IServiceCollection AddPokemoninfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IPokemonRepository, PokeApiPokemonRepository>();
        services.AddSingleton<MemoryPokemonRepository>();
        services.AddScoped<PokemonAdapter>();
        return services;
    }
}