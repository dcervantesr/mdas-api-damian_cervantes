using Pokemon.Type.Domain;

namespace TypeTest.Domain
{
    public class PokemonNameMother 
    {
        public static PokemonName Random()
        {
            return new PokemonName(Faker.Name.First());
        }
    }
}
