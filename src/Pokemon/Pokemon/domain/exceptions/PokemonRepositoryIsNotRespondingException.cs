using System;

namespace Pokemon.Pokemon.Domain
{
    public class PokemonRepositoryIsNotRespondingException : Exception
    {
        public PokemonRepositoryIsNotRespondingException()
            : base("Pokemon repository is not responding")
        { }
    }
}
