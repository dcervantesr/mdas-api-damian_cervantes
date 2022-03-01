namespace Pokemon.Pokemon.Domain
{
    public class PokemonSaver
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonSaver(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public virtual void Execute(Pokemon pokemon)
        {
            _pokemonRepository.Save(pokemon);
        }
    }
}