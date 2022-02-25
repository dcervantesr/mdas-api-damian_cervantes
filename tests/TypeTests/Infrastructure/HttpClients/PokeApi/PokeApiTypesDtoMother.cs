using Pokemon.Type.Infrastructure;

namespace TypeTests.Infrastructure.HttpClients.PokeApi
{
    public class PokeApiTypesDtoMother
    {
        public static PokeApiTypesDto Random()
        {
            PokeApiTypeDto type = PokeApiTypeDtoMother.Random();
            PokeApiTypesDto pokeApiTypesDto = new PokeApiTypesDto(type);

            return pokeApiTypesDto;
        }
    }
}
