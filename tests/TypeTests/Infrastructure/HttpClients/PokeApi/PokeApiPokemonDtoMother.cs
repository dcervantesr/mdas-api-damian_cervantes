using Pokemon.Type.Infrastructure;
using System.Collections.Generic;

namespace TypeTests.Infrastructure.HttpClients.PokeApi
{
    public class PokeApiPokemonDtoMother
    {

        public static PokeApiPokemonDto Random()
        {
            int id = Faker.RandomNumber.Next();
            string name = Faker.Name.First();
            string url = Faker.Internet.Url();
            PokeApiPokemonDto pokeApiPokemonDto = new PokeApiPokemonDto(id, name, url);
            pokeApiPokemonDto.Types = CreateTypes();

            return pokeApiPokemonDto;
        }

        private static List<PokeApiTypesDto> CreateTypes()
        {
            int typesCount = Faker.RandomNumber.Next(1, 10);
            List<PokeApiTypesDto> types = new List<PokeApiTypesDto>();

            for (int i = 0; i < typesCount; i++)
            {
                PokeApiTypesDto type = PokeApiTypesDtoMother.Random();
                types.Add(type);
            }

            return types;
        }
    }
}
