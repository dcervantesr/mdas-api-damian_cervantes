using Microsoft.Extensions.DependencyInjection;
using Pokemon.Type.Domain;

namespace Pokemon.Type.Infrastructure;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddTypeInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ITypeRepository, PokeApiTypeRepository>();

        return services;
    }
}