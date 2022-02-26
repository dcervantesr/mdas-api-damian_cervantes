namespace Users.User.Domain
{
    public class UserFinder
    {
        private readonly IUserRepository _userRepository;

        public UserFinder(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public virtual User Execute(UserId userId)
        {
            var user = _userRepository.Find(userId);
            GuardAgainstUserDoesNotExist(user);
            return user;
        }

        private void GuardAgainstUserDoesNotExist(User user)
        {
            if (user == null)
                throw new UserDoesNotExist();
        }
    }
}
