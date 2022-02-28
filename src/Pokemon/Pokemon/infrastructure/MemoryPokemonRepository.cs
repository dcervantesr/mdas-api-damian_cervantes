using System;
using Microsoft.Extensions.Caching.Memory;

namespace Pokemon.Pokemon.Infrastructure
{
    public class MemoryPokemonRepository
    {
        private readonly IMemoryCache _cache;

        public MemoryPokemonRepository(IMemoryCache cache)
        {
            _cache = cache;
        }

        public int Get(int pokemonId)
        {
            var num = _cache.GetOrCreate($"POKEMON_{pokemonId}", entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
                return 0;
            });
            Console.WriteLine($"Pokemon {pokemonId} favorite counter: {num}");
            return num;
        }

        public void Save(int pokemonId, int favorites)
        {
            Console.WriteLine($"Saving pokemon {pokemonId} with {favorites} favorites");
            _cache.Set($"POKEMON_{pokemonId}", favorites);
        }
    }
}