using Pokemon.Pokemon.Domain;

namespace Pokemon.Pokemon.Infrastructure
{
    internal static class HttpAdapter
    {
        public static Domain.Pokemon PokeApiPokemonDtoToPokemon(PokeApiPokemonDto pokeApiPokemonDto)
        {
            var pokemonId = new PokemonId(pokeApiPokemonDto.Id);
            var pokemonName = new PokemonName(pokeApiPokemonDto.Name);
            var pokemonHeight = new PokemonHeight(pokeApiPokemonDto.Height);
            var pokemonWeight = new PokemonWeight(pokeApiPokemonDto.Weight);

            return Domain.Pokemon.Create(pokemonId, pokemonName, pokemonHeight, pokemonWeight);
        }

    }
}
