using Users.Shared;
using Users.User.Domain;

namespace Users.User.Application
{
    public class AddPokemonFavoriteUseCase
    {
        private readonly UserSaver _userSaver;
        private readonly EventPublisher _eventPublisher;
        private readonly UserFinder _userFinder;

        public AddPokemonFavoriteUseCase(
            UserSaver userSaver,
            EventPublisher eventPublisher,
            UserFinder userFinder
        )
        {
            _userSaver = userSaver;
            _eventPublisher = eventPublisher;
            _userFinder = userFinder;
        }

        public void Execute(Guid userIdparam, int pokemonIdparam)
        {
            var user = _userFinder.Execute(new UserId(userIdparam));
            var pokemonFavorite = PokemonFavorite.Create(new PokemonId(pokemonIdparam));
            user.AddPokemonFavorite(pokemonFavorite);
            _eventPublisher.Publish(user.PullDomainEvents());
            _userSaver.Execute(user);
        }
    }
}
