namespace Users.User.Domain
{
    public class UserCreator
    {
        private readonly IUserRepository _userRepository;

        public UserCreator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public virtual void Execute(UserId userId, UserName userName)
        {
            if (_userRepository.Exists(userId))
                throw new UserAlreadyExistsException();

            var user = User.Create(userId, userName);
            _userRepository.Save(user);
        }
    }
}
