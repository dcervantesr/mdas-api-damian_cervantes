using System.Collections.Generic;

namespace Pokemon.Pokemon.Infrastructure
{
    public class MemoryPokemonRepository
    {
        private Dictionary<int,int> _pokemons = new Dictionary<int, int>();

        public void Save(int pokemonId, int counter)
        {
            _pokemons.Add(pokemonId, counter);
        }

        public int GetFavoriteCounter(int pokemonId)
        {
            return _pokemons[pokemonId];
        }

        public bool Exists(int pokemonId)
        {
            return _pokemons.ContainsKey(pokemonId);
        }
    }
}