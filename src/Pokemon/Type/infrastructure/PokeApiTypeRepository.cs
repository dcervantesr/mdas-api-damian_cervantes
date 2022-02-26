using Pokemon.Type.Domain;

namespace Pokemon.Type.Infrastructure
{
    public class PokeApiTypeRepository : ITypeRepository
    {
        private PokeApiHttpClient _pokeApiHttpClient;
        public PokeApiTypeRepository(PokeApiHttpClient pokeApiHttpClient)
        {
            _pokeApiHttpClient = pokeApiHttpClient;
        }
        public Types FindByPokemonName(string pokemonName)
        {
            var pokemon = _pokeApiHttpClient.FindByPokemonNameAsync(pokemonName).Result;
            return HttpAdapter.PokeApiTypeDtoListToTypesList(pokemon);
        }

    }
}
