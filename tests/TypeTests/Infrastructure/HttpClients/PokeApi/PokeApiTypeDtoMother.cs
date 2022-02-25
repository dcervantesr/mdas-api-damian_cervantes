using Pokemon.Type.Infrastructure;

namespace TypeTests.Infrastructure.HttpClients.PokeApi
{
    public class PokeApiTypeDtoMother
    {
        public static PokeApiTypeDto Random()
        {
            string name = Faker.Name.First();
            string url = Faker.Internet.Url();
            PokeApiTypeDto pokeApiTypeDto = new PokeApiTypeDto(name, url);

            return pokeApiTypeDto;
        }
    }
}
