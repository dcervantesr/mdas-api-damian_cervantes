using Moq;
using Users.User.Domain;

namespace UsersTest.Domain
{

    public class PokemonFavoriteMother 
    {
        public static PokemonFavorite Random()
        {
            return PokemonFavorite.Create(It.IsAny<PokemonId>()); 
        }

        public static PokemonFavorite Random(PokemonId pokemonId)
        {
            return PokemonFavorite.Create(pokemonId);
        }
    }

}