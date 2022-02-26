using Moq;
using Users.Shared;
using Users.User.Application;
using Users.User.Domain;
using Users.User.Infrastructure;
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
            var userGuid = GuidCreator.Execute();
            var userId = UserIdMother.Random(userGuid);
            var user = UserMother.Random(userId, It.IsAny<UserName>());
            var pokemonId = PokemonIdMother.Random();
            var userFinder = new Mock<UserFinder>(It.IsAny<IUserRepository>());
            userFinder.Setup(x => x.Execute(userId)).Returns(user);
            var userSaver = new Mock<UserSaver>(It.IsAny<IUserRepository>());
            var eventPublisher = new Mock<EventPublisher>();
            var addPokemonFavoriteUseCase = new AddPokemonFavoriteUseCase(
                userSaver.Object,
                eventPublisher.Object,
                userFinder.Object
            );

            //When
            addPokemonFavoriteUseCase.Execute(user.Id.Value, pokemonId.Value);

            //Then
            userSaver.Verify(x => x.Execute(user));
        }
    }
}