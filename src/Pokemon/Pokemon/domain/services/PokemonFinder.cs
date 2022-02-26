namespace Pokemon.Pokemon.Domain
{
    public class PokemonFinder
    {

        private readonly IPokemonRepository _pokemonRepository;

        public PokemonFinder(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public virtual Pokemon Execute(PokemonId pokemonId)
        {
            if (!_pokemonRepository.Exists(pokemonId))
                throw new PokemonNotFound();

            return _pokemonRepository.Find(pokemonId);
        }

    }
}
