using Pokemon.Pokemon.Domain;

namespace PokemonTests.Domain
{
    public class PokemonFavoriteCounterMother
    {
        public static PokemonFavoriteCounter Random()
        {
            return new PokemonFavoriteCounter(Faker.RandomNumber.Next(1, 10));
        }
    }
}