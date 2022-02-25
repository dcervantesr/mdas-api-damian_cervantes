using Pokemon.Pokemon.Domain;

namespace Pokemon.Pokemon.Infrastructure
{
    public class PokemonAdapter
    {
        private readonly MemoryPokemonRepository _memoryPokemonRepository;

        public PokemonAdapter(MemoryPokemonRepository memoryPokemonRepository)
        {
            _memoryPokemonRepository = memoryPokemonRepository;
        }

        public Domain.Pokemon PokeApiPokemonDtoToPokemon(PokeApiPokemonDto pokeApiPokemonDto)
        {    
            return Domain.Pokemon.Create(
                new PokemonId(pokeApiPokemonDto.Id),
                new PokemonName(pokeApiPokemonDto.Name),
                new PokemonHeight(pokeApiPokemonDto.Height),
                new PokemonWeight(pokeApiPokemonDto.Weight),
                LoadPokemonFavoriteCounter(pokeApiPokemonDto.Id)
            );
        }

        private PokemonFavoriteCounter LoadPokemonFavoriteCounter(int pokemonId)
        {
            saveIfDoesNotExist(pokemonId);
            return new PokemonFavoriteCounter(_memoryPokemonRepository.GetFavoriteCounter(pokemonId));
        }

        private void saveIfDoesNotExist(int pokemonId)
        {
            if (!_memoryPokemonRepository.Exists(pokemonId))
                _memoryPokemonRepository.Save(pokemonId, 0);
        }
    }
}
