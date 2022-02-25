
using Pokemon.Pokemon.Domain;

namespace Pokemon.Pokemon.Application
{
    public class GetPokemonByPokemonIdUseCase
    {
        private readonly PokemonFinder _pokemonFinder;

        public GetPokemonByPokemonIdUseCase(PokemonFinder pokemonFinder)
        {
            _pokemonFinder = pokemonFinder;
        }

        public Domain.Pokemon Execute(int pokemonIdparam)
        {
            var pokemonId = new PokemonId(pokemonIdparam);

            return _pokemonFinder.Execute(pokemonId);
        }

    }
}
