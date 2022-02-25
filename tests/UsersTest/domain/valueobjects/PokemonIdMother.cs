using Users.User.Domain;

namespace UsersTest.Domain
{
    public class PokemonIdMother
    {
        public static PokemonId Random()
        {
            return new PokemonId(Faker.RandomNumber.Next(0, 100));
        }
    }

}
