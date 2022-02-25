using Pokemon.Type.Domain;
using Pokemon.Type.Infrastructure;
using RichardSzalay.MockHttp;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using TypeTests.Infrastructure.HttpClients.PokeApi;
using Xunit;

namespace TypeTests.Infrastructure
{
    public class PokeApiTypeRepositoryTest
    {
        [Fact]
        public void Should_Find_Some_Types_By_PokemonName()
        {
            //Given
            string pokemonUrl = "https://pokeapi.co/api/v2/pokemon";
            var mockHttp = new MockHttpMessageHandler();
            var pokeApiPokemonDto = PokeApiPokemonDtoMother.Random();
            var response = JsonSerializer.Serialize(pokeApiPokemonDto);
            mockHttp.When($"{pokemonUrl}/{pokeApiPokemonDto.Name}").Respond("application/json", response);
            var httpClient = new HttpClient(mockHttp);
            var pokeApiHttpClient = new PokeApiHttpClient(httpClient);
            var pokeApiTypeRepository = new PokeApiTypeRepository(pokeApiHttpClient);

            //When
            var types = pokeApiTypeRepository.FindByPokemonName(new PokemonName(pokeApiPokemonDto.Name));

            //Then
            Assert.Equal(pokeApiPokemonDto.Types.Count(), types.Count());
            Assert.Equal(pokeApiPokemonDto.Types.First().Type.Name, types.First().Name.Value);
        }
    }
}
