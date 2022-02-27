using Moq;
using Shared.MessageBroker;
using Users.User.Application;
using Users.User.Domain;
using UsersTest.Domain;
using Xunit;

namespace UsersTest.Application
{
    public class AddPokemonFavoriteUseCaseTest
    {
        [Fact]
        public void Should_Add_A_PokemonFavorite()
        {
            //Given
            var user = UserMother.Random(UserIdMother.Random(), UserNameMother.Random());
            var pokemonId = PokemonIdMother.Random();
            var userFinder = new Mock<UserFinder>(It.IsAny<IUserRepository>());
            userFinder.Setup(x => x.Execute(It.IsAny<UserId>())).Returns(user);
            var userSaver = new Mock<UserSaver>(It.IsAny<IUserRepository>());
            userSaver.Setup(x => x.Execute(It.IsAny<User>()));
            var eventPublisher = new Mock<IBus>();
            var addPokemonFavoriteUseCase = new AddPokemonFavoriteUseCase(
                userSaver.Object,
                eventPublisher.Object,
                userFinder.Object
            );

            //When
            addPokemonFavoriteUseCase.Execute(user.Id.Value, pokemonId.Value);

            //Then
            userSaver.Verify(v => v.Execute(It.IsAny<User>()));
        }
    }
}