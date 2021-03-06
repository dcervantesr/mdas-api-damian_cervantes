using System.Collections.Generic;
using Moq;
using Pokemon.Type.Application;
using Pokemon.Type.Domain;
using TypeTest.Domain;
using Xunit;

namespace TypeTest.Application
{
    public class GetTypesByPokemonNameUseCaseTest
    {
        [Fact]
        public void Should_Return_A_Types_By_PokemonName()
        {
            //Given
            var findByPokemonName = new Mock<FindByPokemonName>(It.IsAny<ITypeRepository>());
            var type = TypeMother.Random();
            findByPokemonName.Setup(_ => _.Execute(It.IsAny<string>())).Returns(new Types { type });
            var getTypesByPokemonNameUseCase = new GetTypesByPokemonNameUseCase(findByPokemonName.Object);

            //When
            var result = getTypesByPokemonNameUseCase.Execute(Faker.Name.First());

            //Then
            Assert.Equal(type.Name.Value, result[0].Name.Value);
        }
    }
}
