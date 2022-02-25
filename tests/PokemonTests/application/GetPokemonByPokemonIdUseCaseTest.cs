using Moq;
using Pokemon.Pokemon.Application;
using Pokemon.Pokemon.Domain;
using PokemonTests.Domain;
using Xunit;

namespace PokemonTests.Application
{
    public class GetPokemonByPokemonIdUseCaseTest
    {
        [Fact]
        public void Should_Return_Pokemon_When_Pokemon_Exists()
        {
            //Given
            var pokemonFinder = new Mock<PokemonFinder>(It.IsAny<IPokemonRepository>());
            var pokemon = PokemonMother.Random();
            pokemonFinder.Setup(_ => _.Execute(It.IsAny<PokemonId>())).Returns(pokemon);
            var getPokemonByPokemonIdUseCase = new GetPokemonByPokemonIdUseCase(pokemonFinder.Object);

            //When
            var result = getPokemonByPokemonIdUseCase.Execute(1);

            //Then
            Assert.Equal(pokemon.PokemonId.Value, result.PokemonId.Value);
        }
    }
}