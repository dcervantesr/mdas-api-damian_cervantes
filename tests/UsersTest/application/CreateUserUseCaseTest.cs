using Moq;
using Users.User.Application;
using Users.User.Domain;
using Users.User.Infrastructure;
using Xunit;

namespace UsersTest.Application
{
    public class CreateUserUseCaseTest
    {
        [Fact]
        public void Should_Create_A_User()
        {
            //Given
            var userCreator = new Mock<UserCreator>(It.IsAny<IUserRepository>());
            var createUserUseCase = new CreateUserUseCase(userCreator.Object);
            var userId = GuidCreator.Execute();
            var name = It.IsAny<string>();

            //When
            createUserUseCase.Execute(userId, name);

            //Then
            userCreator.Verify(v => v.Execute(It.IsAny<UserId>(), It.IsAny<UserName>()));
        }
    }
}