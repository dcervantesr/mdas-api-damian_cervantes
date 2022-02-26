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
            GuardAgainstUserAlreadyExists(userId);
            var user = User.Create(userId, userName);
            _userRepository.Save(user);
        }

        private void GuardAgainstUserAlreadyExists(UserId userId)
        {
            if (_userRepository.Exists(userId))
                throw new UserAlreadyExists();
        }
    }
}
