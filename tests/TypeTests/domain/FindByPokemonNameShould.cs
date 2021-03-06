using System.Collections.Generic;
using Moq;
using Pokemon.Type.Domain;
using Xunit;

namespace TypeTest.Domain
{
    public class FindByPokemonNameShould
    {
        [Fact]
        public void Return_A_Types_By_PokemonName()
        {
            //Given
            var typeRepository = new Mock<ITypeRepository>();
            var type = TypeMother.Random();
            typeRepository.Setup(_ => _.FindByPokemonName(It.IsAny<string>())).Returns(new Types { type });
            var _findByPokemonName = new FindByPokemonName(typeRepository.Object);

            //When 
            var result = _findByPokemonName.Execute(Faker.Name.First());

            //then
            Assert.Equal(type.Name, result[0].Name);
        }

        [Fact]
        public void Throw_An_Exception_When_Pokemon_Does_Not_Exists()
        {
            //Given
            var typeRepository = new Mock<ITypeRepository>();
            typeRepository.Setup(_ => _.FindByPokemonName(It.IsAny<string>())).Returns(new Types());
            var _findByPokemonName = new FindByPokemonName(typeRepository.Object);

            //When - Then
            Assert.Throws<PokemonNotFound>(() => _findByPokemonName.Execute(Faker.Name.First()));
        }
    }
}