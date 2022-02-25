namespace Pokemon.Pokemon.Domain
{
    public interface IPokemonRepository
    {
        bool Exists(PokemonId pokemonId);

        Pokemon Find(PokemonId pokemonId);
    }
}
