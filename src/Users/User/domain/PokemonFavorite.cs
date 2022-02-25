namespace Users.User.Domain;
public class PokemonFavorite
{
    private readonly PokemonId _pokemonId;

    private PokemonFavorite( PokemonId pokemonId)
    {
        _pokemonId = pokemonId;
    }

    public static PokemonFavorite Create(  PokemonId pokemonId )
    {
        return new PokemonFavorite( pokemonId);
    }

    public PokemonId PokemonId => _pokemonId;

}
