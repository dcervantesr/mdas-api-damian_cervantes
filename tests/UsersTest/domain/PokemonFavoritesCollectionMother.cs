using Users.User.Domain;

namespace UsersTest.Domain
{

    public class PokemonFavoritesCollectionMother 
    {
        public static PokemonFavoritesCollection Random()
        {
            var pokemonFavorite = PokemonFavoriteMother.Random();
            var pokemonFavoritesCollection = new PokemonFavoritesCollection();
            pokemonFavoritesCollection.AddPokemonFavorite(pokemonFavorite);
            return pokemonFavoritesCollection;
        }

        public static PokemonFavoritesCollection Random(PokemonFavorite pokemonFavorite)
        {
            var pokemonFavoritesCollection = new PokemonFavoritesCollection();
            pokemonFavoritesCollection.AddPokemonFavorite(pokemonFavorite);
            return pokemonFavoritesCollection;
        }
    }

}