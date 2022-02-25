using System.Collections.Generic;

namespace Pokemon.Type.Domain
{
    public interface ITypeRepository
    {
        public List<Type> FindByPokemonName(PokemonName pokemonName);
    }
} 
