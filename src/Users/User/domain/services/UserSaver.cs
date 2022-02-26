namespace Users.User.Domain
{
    public class UserSaver
    {
        private readonly IUserRepository _userRepository;

        public UserSaver(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public virtual void Execute(User user)
        {
            _userRepository.Save(user);
        }
    }
}
