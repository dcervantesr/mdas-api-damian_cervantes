using Pokemon.Type.Application;

namespace PokemonApi
{
    public static class TypeGetAdapter
    {
        public static GetTypesByPokemonNameQuery GetByPokemonNameToGetTypesByPokemonNameQuery(string pokemonName)
        {
            return new GetTypesByPokemonNameQuery(pokemonName);
        }
    }
}
