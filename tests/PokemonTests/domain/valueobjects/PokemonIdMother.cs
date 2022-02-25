using Pokemon.Pokemon.Domain;

namespace PokemonTests.Domain
{
    public class PokemonIdMother
    {
        public static PokemonId Random()
        {
            return new PokemonId(Faker.RandomNumber.Next(1, 100));
        }
    }
}