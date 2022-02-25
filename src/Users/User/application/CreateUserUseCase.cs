using Users.User.Domain;

namespace Users.User.Application
{
    public class CreateUserUseCase
    {
        private readonly UserCreator _userCreator;

        public CreateUserUseCase(UserCreator userCreator)
        {
            _userCreator = userCreator;
        }

        public void Execute(Guid id, string name)
        {
            UserId userId = new UserId(id);
            UserName userName = new UserName(name);

            _userCreator.Execute(userId, userName);
        }

    }
}
