namespace Pokemon.Type.Domain
{
    public readonly struct PokemonName
    {
        public string Value { get; } 
        
        public PokemonName(string name)
        {
            Value = name;
        }
    }
}
