namespace Pokemon.Pokemon.Domain
{
    public class PokemonFavoriteCounter
    {
        public int Value { get; }

        public PokemonFavoriteCounter(int counter)
        {
            Value = counter;
        }
    }
}