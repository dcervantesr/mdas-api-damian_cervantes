namespace Pokemon.Pokemon.Domain
{
    public class Pokemon
    {
        private PokemonId _pokemonId;
        private PokemonName _pokemonName;
        private PokemonHeight _pokemonHeight;
        private PokemonWeight _pokemonWeight;
        private PokemonFavoriteCounter _pokemonFavoriteCounter;

        private Pokemon(
            PokemonId pokemonId,
            PokemonName pokemonName,
            PokemonHeight pokemonHeight,
            PokemonWeight pokemonWeight,
            PokemonFavoriteCounter pokemonFavoriteCounter
        )
        {
            _pokemonId = pokemonId;
            _pokemonName = pokemonName;
            _pokemonHeight = pokemonHeight;
            _pokemonWeight = pokemonWeight;
            _pokemonFavoriteCounter = pokemonFavoriteCounter;
        }

        public static Pokemon Create(
            PokemonId pokemonId,
            PokemonName pokemonName,
            PokemonHeight pokemonHeight,
            PokemonWeight pokemonWeight,
            PokemonFavoriteCounter pokemonFavoriteCounter
        )
        {
            return new Pokemon(pokemonId, pokemonName, pokemonHeight, pokemonWeight, pokemonFavoriteCounter);
        }

        public PokemonId PokemonId => _pokemonId;
        public PokemonName PokemonName => _pokemonName;
        public PokemonHeight PokemonHeight => _pokemonHeight;
        public PokemonWeight PokemonWeight => _pokemonWeight;
        public PokemonFavoriteCounter PokemonFavoriteCounter => _pokemonFavoriteCounter;
        public void IncrementFavoriteCounter() => 
            _pokemonFavoriteCounter = new PokemonFavoriteCounter(_pokemonFavoriteCounter.Value + 1);
    }
}