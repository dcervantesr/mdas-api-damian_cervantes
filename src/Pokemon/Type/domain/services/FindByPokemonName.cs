using System.Collections.Generic;

namespace Pokemon.Type.Domain {

    public class FindByPokemonName {
        private readonly ITypeRepository _typeRepository;
        public FindByPokemonName(ITypeRepository typeRepository) {
            _typeRepository = typeRepository;
        }
        
        public virtual List<Type> Execute(PokemonName pokemonName) {
            var types = _typeRepository.FindByPokemonName(pokemonName);
            if (types.Count == 0)
            {
                throw new PokemonNotFoundException();
            }
            return types;
        }
    }
}
