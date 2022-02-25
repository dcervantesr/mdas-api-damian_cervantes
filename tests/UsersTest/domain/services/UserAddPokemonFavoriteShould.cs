using Moq;
using Users.User.Domain;
using Xunit;

namespace UsersTest.Domain
{
    public class UserAddPokemonFavoriteShould
    {
        private UserAddPokemonFavorite? _userAddPokemonFavorite;

        [Fact]
        public void Add_A_PokemonFavorite_To_User()
        {
            //Given
            var userId = UserIdMother.Random();
            var user = UserMother.Random();
            var pokemonFavorite = PokemonFavoriteMother.Random();

            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(_ => _.Exists(It.IsAny<UserId>())).Returns(true);
            userRepository.Setup(_ => _.Find(It.IsAny<UserId>())).Returns(user);
            _userAddPokemonFavorite = new UserAddPokemonFavorite(userRepository.Object);

            //When
            _userAddPokemonFavorite.Execute(userId, pokemonFavorite);

            //Then
            userRepository.Verify(v => v.Save(It.IsAny<User>()));
        }

        [Fact]
        public void Throw_An_Exception_When_User_Does_Not_Exists()
        {
            //Given
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(_ => _.Exists(It.IsAny<UserId>())).Returns(false);
            _userAddPokemonFavorite = new UserAddPokemonFavorite(userRepository.Object);

            var userId = UserIdMother.Random();
            var pokemonFavorite = PokemonFavoriteMother.Random();

            //When - Then
            Assert.Throws<UserDoesNotExistException>(() => _userAddPokemonFavorite.Execute(userId, pokemonFavorite));
            userRepository.Verify(v => v.Save(It.IsAny<User>()), Times.Never);
        }
    }
}
