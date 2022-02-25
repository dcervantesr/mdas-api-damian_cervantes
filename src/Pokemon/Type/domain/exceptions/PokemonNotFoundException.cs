using System;

namespace Pokemon.Type.Domain
{
    public class PokemonNotFoundException : Exception
    {
        public PokemonNotFoundException()
            : base("Pokemon not found")
        { }
    }
}
