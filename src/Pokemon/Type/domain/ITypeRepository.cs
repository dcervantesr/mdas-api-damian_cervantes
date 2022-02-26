namespace Pokemon.Type.Domain
{
    public interface ITypeRepository
    {
        public Types FindByPokemonName(string pokemonName);
    }
} 
