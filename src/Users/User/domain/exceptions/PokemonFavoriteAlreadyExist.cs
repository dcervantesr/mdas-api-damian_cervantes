namespace Users.User.Domain
{
    public class PokemonFavoriteAlreadyExist : Exception
    {
        public PokemonFavoriteAlreadyExist() 
            : base("Pokemon already added to favorites")
        {
        }
    }
}
