namespace Users.User.Domain
{
    public class UserAddPokemonFavorite
    {
        private readonly IUserRepository _userRepository;

        public UserAddPokemonFavorite(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public virtual void Execute(UserId userId, PokemonFavorite pokemonFavorite)
        {
            if (!_userRepository.Exists(userId))
                throw new UserDoesNotExistException();

            var user = _userRepository.Find(userId);

            user.PokemonFavorites.AddPokemonFavorite(pokemonFavorite);

            _userRepository.Save(user);
        }
    }
}
