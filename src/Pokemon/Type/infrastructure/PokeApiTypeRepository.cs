using System.Collections.Generic;
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
        public List<Domain.Type> FindByPokemonName(string pokemonName)
        {
            var pokemon = _pokeApiHttpClient.FindByPokemonNameAsync(pokemonName).Result;

            List<Domain.Type> types = HttpAdapter.PokeApiTypeDtoListToTypesList(pokemon);
            return types;
        }

    }
}
