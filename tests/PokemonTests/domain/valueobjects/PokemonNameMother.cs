using Pokemon.Pokemon.Domain;

namespace PokemonTests.Domain
{
    public class PokemonNameMother
    {
        public static PokemonName Random()
        {
            return new PokemonName(Faker.Name.First());
        }
    }
}