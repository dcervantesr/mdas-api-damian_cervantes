using Moq;
using Pokemon.Pokemon.Application;
using Pokemon.Pokemon.Domain;
using PokemonTests.Domain;
using Xunit;

namespace PokemonTests.Application
{
    public class AddPokemonAsFavoriteUseCaseTest
    {
        [Fact]
        public void Should_Invoke_PokemonSaver()
        {
            //Given
            var pokemonFinder = new Mock<PokemonFinder>(It.IsAny<IPokemonRepository>());
            var pokemon = PokemonMother.Random();
            pokemonFinder.Setup(_ => _.Execute(It.IsAny<PokemonId>())).Returns(pokemon);
            var pokemonSaver = new Mock<PokemonSaver>(It.IsAny<IPokemonRepository>());
            pokemonSaver.Setup(_ => _.Execute(It.IsAny<Pokemon.Pokemon.Domain.Pokemon>()));
            var addPokemonAsFavoriteUseCase = new AddPokemonAsFavoriteUseCase(pokemonFinder.Object, pokemonSaver.Object);

            //When
            addPokemonAsFavoriteUseCase.Execute(Faker.RandomNumber.Next(1,100));

            //Then
            pokemonSaver.Verify(_ => _.Execute(It.IsAny<Pokemon.Pokemon.Domain.Pokemon>()), Times.Once);
        }
    }
}
