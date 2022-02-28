namespace Pokemon.Type.Domain {

    public class FindByPokemonName {
        private readonly ITypeRepository _typeRepository;
        public FindByPokemonName(ITypeRepository typeRepository) {
            _typeRepository = typeRepository;
        }
        
        public virtual Types Execute(string pokemonName) {
            var types = _typeRepository.FindByPokemonName(pokemonName);
            if (types.Count == 0)
            {
                throw new PokemonNotFound();
            }
            return types;
        }
    }
}
