using Pokemon.Pokemon.Infrastructure;

namespace PokemonApi
{
    public static class PokemonGetAdapter
    {
        public static GetPokemonDto PokemonToGetPokemonDto(Pokemon.Pokemon.Domain.Pokemon pokemon)
        {
            var getPokemonDto = new GetPokemonDto
            {
                Id = pokemon.PokemonId.Value,
                Name = pokemon.PokemonName.Value,
                Height = pokemon.PokemonHeight.Value,
                Weight = pokemon.PokemonWeight.Value,
                FavoriteCounter = pokemon.PokemonFavoriteCounter.Value
            };

            return getPokemonDto;
        }
    }
}
