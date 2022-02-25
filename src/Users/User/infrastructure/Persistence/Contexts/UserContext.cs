namespace Users.User.Infrastructure
{
    public partial class UserContext
    {

        public UserContext()
        {
            Users = new List<Domain.User>();
            Favorites = new List<Domain.PokemonFavorite>();
        }

        private IEnumerable<Domain.User> Users { get; set; }
        private IEnumerable<Domain.PokemonFavorite> Favorites { get; set; }

        public List<TEntity> Set<TEntity>()
        {
            List<TEntity> entities = new List<TEntity>();
            string className = typeof(TEntity).Name;

            switch (className)
            {
                case "User":
                    entities = (List<TEntity>)Users;
                    break;
                case "PokemonFavorite":
                    entities = (List<TEntity>)Favorites;
                    break;
                default:
                    break;
            }
            return entities;
        }
    }
}
