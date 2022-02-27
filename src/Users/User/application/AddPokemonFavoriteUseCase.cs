using Shared.MessageBroker;
using Users.User.Domain;

namespace Users.User.Application
{
    public class AddPokemonFavoriteUseCase
    {
        private readonly UserSaver _userSaver;
        private readonly IBus _busControl;
        private readonly UserFinder _userFinder;

        public AddPokemonFavoriteUseCase(
            UserSaver userSaver,
            IBus busControl,
            UserFinder userFinder
        )
        {
            _userSaver = userSaver;
            _busControl = busControl;
            _userFinder = userFinder;
        }

        public void Execute(Guid userIdparam, int pokemonIdparam)
        {
            var user = _userFinder.Execute(new UserId(userIdparam));
            var pokemonFavorite = PokemonFavorite.Create(new PokemonId(pokemonIdparam));
            user.AddPokemonFavorite(pokemonFavorite);
            _busControl.Publish(Exchange.DomainEvents, Queue.Favorites, user.PullDomainEvents()).Wait();
            _userSaver.Execute(user);
        }
    }
}
