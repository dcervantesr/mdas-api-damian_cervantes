namespace Pokemon.Pokemon.Domain
{
    public class PokemonName
    {
        public string Value { get; } 
        
        public PokemonName(string name)
        {
            Value = name;
        }
    }
}
