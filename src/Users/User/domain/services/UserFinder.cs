namespace Users.User.Domain {
    public class UserFinder {
        private readonly IUserRepository _userRepository;

        public UserFinder(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        public User Execute(UserId userId) {
            return _userRepository.Find(userId);
        }
    }
}
