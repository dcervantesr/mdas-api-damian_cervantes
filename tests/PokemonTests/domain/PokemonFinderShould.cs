using Moq;
using Pokemon.Pokemon.Domain;
using Xunit;

namespace PokemonTests.Domain
{
    public class PokemonFinderShould
    {
        [Fact]
        public void Return_A_Pokemon()
        {
            //Given
            var pokemonRepository = new Mock<IPokemonRepository>();
            var pokemon = PokemonMother.Random();
            pokemonRepository.Setup(_ => _.Exists(It.IsAny<PokemonId>())).Returns(true);
            pokemonRepository.Setup(_ => _.Find(It.IsAny<PokemonId>())).Returns(pokemon);
            var _pokemonFinder = new PokemonFinder(pokemonRepository.Object);

            //When
            var result = _pokemonFinder.Execute(PokemonIdMother.Random());

            //Then
            Assert.Equal(pokemon, result);
            pokemonRepository.Verify(_ => _.Exists(It.IsAny<PokemonId>()), Times.Once);
            pokemonRepository.Verify(_ => _.Find(It.IsAny<PokemonId>()), Times.Once);
        }

        [Fact]
        public void Throw_An_Exception_When_Pokemon_Does_Not_Exists()
        {
            //Given
            var pokemonRepository = new Mock<IPokemonRepository>();
            pokemonRepository.Setup(_ => _.Exists(It.IsAny<PokemonId>())).Returns(false);
            var _pokemonFinder = new PokemonFinder(pokemonRepository.Object);

            //When - Then
            Assert.Throws<PokemonNotFoundException>(() => _pokemonFinder.Execute(PokemonIdMother.Random()));
            pokemonRepository.Verify(_ => _.Exists(It.IsAny<PokemonId>()), Times.Once);
            pokemonRepository.Verify(_ => _.Find(It.IsAny<PokemonId>()), Times.Never);
        }
    }
}