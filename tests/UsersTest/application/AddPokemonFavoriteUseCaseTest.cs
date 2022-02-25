using Moq;
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
            var userAddPokemonFavorite = new Mock<UserAddPokemonFavorite>(It.IsAny<IUserRepository>());
            userAddPokemonFavorite.Setup(_ => _.Execute(It.IsAny<UserId>(), It.IsAny<PokemonFavorite>()));
            var addPokemonFavoriteUseCase = new AddPokemonFavoriteUseCase(userAddPokemonFavorite.Object);

            //When
            addPokemonFavoriteUseCase.Execute(user.Id.Value, pokemonId.Value);

            //Then
            userAddPokemonFavorite.Verify(v => v.Execute(It.IsAny<UserId>(), It.IsAny<PokemonFavorite>()));
        }
    }
}