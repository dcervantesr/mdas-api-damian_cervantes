using Users.Shared;

namespace Users.User.Domain
{
    public class PokemonFavoriteAddedEvent : DomainEvent
    {
        public PokemonFavoriteAddedEvent(string aggregateId) : base(aggregateId)
        {
        }

        public override string Type() => "pokemonfavorite.added";
    }
}