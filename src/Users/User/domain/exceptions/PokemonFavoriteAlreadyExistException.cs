namespace Users.User.Domain
{
    public class PokemonFavoriteAlreadyExistException : Exception
    {
        public PokemonFavoriteAlreadyExistException() 
            : base("Pokemon already added to favorites")
        {
        }
    }
}
