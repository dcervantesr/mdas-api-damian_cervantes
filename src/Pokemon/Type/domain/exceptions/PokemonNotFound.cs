using System;

namespace Pokemon.Type.Domain
{
    public class PokemonNotFound : Exception
    {
        public PokemonNotFound()
            : base("Pokemon not found")
        { }
    }
}
