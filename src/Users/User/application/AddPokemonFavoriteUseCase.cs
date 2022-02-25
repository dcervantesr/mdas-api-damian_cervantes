using Users.User.Domain;

namespace Users.User.Application
{
    public class AddPokemonFavoriteUseCase
    {
        private readonly UserAddPokemonFavorite _userAddPokemonFavorite;

        public AddPokemonFavoriteUseCase(UserAddPokemonFavorite userAddPokemonFavorite)
        {
            _userAddPokemonFavorite = userAddPokemonFavorite;
        }

        public void Execute(Guid userIdparam, int pokemonIdparam)
        {
            var userId = new UserId(userIdparam);
            var pokemonId = new PokemonId(pokemonIdparam);
            var pokemonFavorite = PokemonFavorite.Create(pokemonId);

            _userAddPokemonFavorite.Execute(userId, pokemonFavorite);
        }
    }
}
