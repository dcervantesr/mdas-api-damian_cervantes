namespace Pokemon.Pokemon.Domain
{
    public class Pokemon
    {
        private readonly PokemonId _pokemonId;
        private readonly PokemonName _pokemonName;
        private readonly PokemonHeight _pokemonHeight;
        private readonly PokemonWeight _pokemonWeight;

        private Pokemon(PokemonId pokemonId, PokemonName pokemonName, PokemonHeight pokemonHeight, PokemonWeight pokemonWeight)
        {
            _pokemonId = pokemonId;
            _pokemonName = pokemonName;
            _pokemonHeight = pokemonHeight;
            _pokemonWeight = pokemonWeight;
        }

        public static Pokemon Create(PokemonId pokemonId, PokemonName pokemonName, PokemonHeight pokemonHeight, PokemonWeight pokemonWeight)
        {
            return new Pokemon(pokemonId, pokemonName, pokemonHeight, pokemonWeight);
        }

        public PokemonId PokemonId => _pokemonId;
        public PokemonName PokemonName => _pokemonName;
        public PokemonHeight PokemonHeight => _pokemonHeight;
        public PokemonWeight PokemonWeight => _pokemonWeight;
    }
}