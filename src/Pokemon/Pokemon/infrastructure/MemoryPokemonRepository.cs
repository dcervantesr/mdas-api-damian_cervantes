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
            return _cache.GetOrCreate($"POKEMON_{pokemonId}", entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
                return 0;
            });
        }

        public void Save(int pokemonId, int favorites)
        {
            _cache.Set($"POKEMON_{pokemonId}", favorites);
        }
    }
}