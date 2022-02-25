using Pokemon.Pokemon.Domain;

namespace PokemonTests.Domain
{
    public class PokemonHeightMother
    {
        public static PokemonHeight Random()
        {
            return new PokemonHeight(Faker.RandomNumber.Next(1, 100));
        }
    }
}