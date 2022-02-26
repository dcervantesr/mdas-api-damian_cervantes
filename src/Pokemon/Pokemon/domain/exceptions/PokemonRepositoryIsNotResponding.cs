using System;

namespace Pokemon.Pokemon.Domain
{
    public class PokemonRepositoryIsNotResponding : Exception
    {
        public PokemonRepositoryIsNotResponding()
            : base("Pokemon repository is not responding")
        { }
    }
}
