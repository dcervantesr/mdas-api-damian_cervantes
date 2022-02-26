using System;

namespace Pokemon.Pokemon.Domain
{
    public class PokemonNotFound : Exception
    {
        public PokemonNotFound()
            : base("Pokemon not found")
        { }
    }
}
