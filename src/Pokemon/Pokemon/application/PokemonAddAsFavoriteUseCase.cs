using System;
using Pokemon.Pokemon.Domain;

namespace Pokemon.Pokemon.Application
{
    public class PokemonAddAsFavoriteUseCase
    {
        private readonly PokemonFinder _pokemonFinder;
        private readonly PokemonSaver _pokemonSaver;

        public PokemonAddAsFavoriteUseCase(
            PokemonFinder pokemonFinder,
            PokemonSaver pokemonSaver
        )
        {
            _pokemonFinder = pokemonFinder;
            _pokemonSaver = pokemonSaver;
        }

        public void Execute(int pokemonId)
        {
            var pokemon = _pokemonFinder.Execute(new PokemonId(pokemonId));
            Console.WriteLine($"Pokemon {pokemon.PokemonFavoriteCounter} favorites before.");
            pokemon.IncrementFavoriteCounter();
            Console.WriteLine($"Pokemon {pokemon.PokemonFavoriteCounter} favorites after.");
            _pokemonSaver.Execute(pokemon);
        }
    }
}