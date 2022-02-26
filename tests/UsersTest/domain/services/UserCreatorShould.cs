using Moq;
using Users.User.Domain;
using Xunit;

namespace UsersTest.Domain
{
    public class UserCreatorShould
    {
        [Fact]
        public void Create_A_User()
        {
            //Given
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(_ => _.Exists(It.IsAny<UserId>())).Returns(false);
            var _userCreator = new UserCreator(userRepository.Object);

            var userId = UserIdMother.Random();
            var userName = UserNameMother.Random();

            //When
            _userCreator.Execute(userId, userName);

            //Then
            userRepository.Verify(v => v.Save(It.IsAny<User>()));
        }

        [Fact]
        public void Throw_An_Exception_When_User_Already_Exists()
        {
            //Given
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(_ => _.Exists(It.IsAny<UserId>())).Returns(true);
            var _userCreator = new UserCreator(userRepository.Object);

            var userId = UserIdMother.Random();
            var userName = UserNameMother.Random();

            //When - Then
            Assert.Throws<UserAlreadyExists>(() => _userCreator.Execute(userId, userName));
        }
    }
}
