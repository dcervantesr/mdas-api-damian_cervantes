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
        public List<Domain.Type> FindByPokemonName(PokemonName pokemonName)
        {
            var pokemon = _pokeApiHttpClient.FindByPokemonNameAsync(pokemonName.Value).Result;

            List<Domain.Type> types = HttpAdapter.PokeApiTypeDtoListToTypesList(pokemon);
            return types;
        }

    }
}
