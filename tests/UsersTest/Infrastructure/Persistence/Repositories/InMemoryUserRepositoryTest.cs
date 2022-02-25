using Users.User.Infrastructure;
using UsersTest.Domain;
using Xunit;

namespace UsersTest.Infrastructure.Persistence.Repositories
{
    public class InMemoryUserRepositoryTest
    {
        [Fact]
        public void Should_Find_A_User()
        {
            //Given
            var context = new UserContext();
            var userRepository = new InMemoryUserRepository(context);
            var user = UserMother.Random();
            userRepository.Save(user);
            //When
            var userFromRepository = userRepository.Find(user.Id);
            //Then
            Assert.Equal(user.Id, userFromRepository.Id);
        }

        [Fact]
        public void Should_Exists_A_User()
        {
            //Given
            var context = new UserContext();
            var userRepository = new InMemoryUserRepository(context);
            var user = UserMother.Random();
            userRepository.Save(user);
            //When
            var exists = userRepository.Exists(user.Id);
            //Then
            Assert.True(exists);
        }

        [Fact]
        public void Should_Save_A_User()
        {
            //Given
            var context = new UserContext();
            var userRepository = new InMemoryUserRepository(context);
            var user = UserMother.Random();
            //When
            userRepository.Save(user);
            var exists = userRepository.Exists(user.Id);
            //Then
            Assert.True(exists);
        }
    }
}
