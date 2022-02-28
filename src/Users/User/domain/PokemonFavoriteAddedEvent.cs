using Shared.MessageBroker;

namespace Users.User.Domain
{
    public class PokemonFavoriteAddedEvent : DomainEvent
    {
        public PokemonFavoriteAddedEvent(string aggregateId) 
            : base(aggregateId, null, "pokemonfavorite.added")
        {
        }
    }
}