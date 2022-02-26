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
            guardAgainstUserDoesNotExist(userId);
            var user = _userRepository.Find(userId);
            user.AddPokemonFavorite(pokemonFavorite);
            _userRepository.Save(user);
        }

        private void guardAgainstUserDoesNotExist(UserId userId)
        {
            if (!_userRepository.Exists(userId))
                throw new UserDoesNotExist();
        }
    }
}
