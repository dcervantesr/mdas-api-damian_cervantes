using Microsoft.Extensions.DependencyInjection;
using Pokemon.Type.Application;

namespace Pokemon.Type.Infrastructure;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddTypeApplication(this IServiceCollection services)
    {
        services.AddTransient<GetTypesByPokemonNameUseCase>();
        return services;
    }
}