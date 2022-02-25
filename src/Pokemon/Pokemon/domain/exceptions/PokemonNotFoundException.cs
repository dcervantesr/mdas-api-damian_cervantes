using System;

namespace Pokemon.Pokemon.Domain
{
    public class PokemonNotFoundException : Exception
    {
        public PokemonNotFoundException()
            : base("Pokemon not found")
        { }
    }
}
