namespace Pokemon.Pokemon.Domain
{
    public readonly struct PokemonId 
    {
        public int Value { get; }

        public PokemonId(int id)
        {
            Value = id;
        }

    }
}
