using Users.User.Domain;

namespace Users.User.Application
{
    public class AddPokemonFavoriteUseCase
    {
        private readonly UserAddPokemonFavorite _userAddPokemonFavorite;
        private readonly PokemonFavoritePublisher _pokemonFavoritePublisher;

        public AddPokemonFavoriteUseCase(
            UserAddPokemonFavorite userAddPokemonFavorite,
            PokemonFavoritePublisher pokemonFavoritePublisher
        )
        {
            _userAddPokemonFavorite = userAddPokemonFavorite;
            _pokemonFavoritePublisher = pokemonFavoritePublisher;
        }

        public void Execute(Guid userIdparam, int pokemonIdparam)
        {
            var userId = new UserId(userIdparam);
            var pokemonId = new PokemonId(pokemonIdparam);
            var pokemonFavorite = PokemonFavorite.Create(pokemonId);
            _userAddPokemonFavorite.Execute(userId, pokemonFavorite);
            _pokemonFavoritePublisher.Publish(pokemonFavorite.PokemonId.Value);
        }
    }
}
