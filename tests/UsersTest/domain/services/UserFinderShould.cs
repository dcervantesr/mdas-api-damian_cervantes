using Moq;
using Users.User.Domain;
using Xunit;

namespace UsersTest.Domain
{
    public class UserFinderShould
    {
        [Fact]
        public void Return_The_User()
        {
            //Given        
            var user = UserMother.Random();
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(_ => _.Find(It.IsAny<UserId>())).Returns(user);
            var _userFinder = new UserFinder(userRepository.Object);

            //When
            var result = _userFinder.Execute(user.Id);

            //Then
            userRepository.Verify(v => v.Save(It.IsAny<User>()));
            Assert.Equal(user.Id.Value, result.Id.Value);
        }

        [Fact]
        public void Throw_An_Exception_When_User_Does_Not_Exists()
        {
            //Given
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(_ => _.Find(It.IsAny<UserId>())).Returns((User)null);
            var _userFinder = new UserFinder(userRepository.Object);

            //When - Then
            Assert.Throws<UserDoesNotExist>(() => _userFinder.Execute(UserIdMother.Random()));
            userRepository.Verify(v => v.Find(It.IsAny<UserId>()), Times.Once);
        }
    }
}
