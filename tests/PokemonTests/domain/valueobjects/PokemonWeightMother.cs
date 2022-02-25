using Pokemon.Pokemon.Domain;

namespace PokemonTests.Domain
{
    public class PokemonWeightMother
    {
        public static PokemonWeight Random()
        {
            return new PokemonWeight(Faker.RandomNumber.Next(1, 100));
        }
    }
}