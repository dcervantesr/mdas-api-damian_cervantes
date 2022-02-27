using Shared.MessageBroker;

namespace Pokemon.Pokemon.Infrastructure
{
    public class PokemonFavoriteAddedEvent : DomainEvent
    {
        public PokemonFavoriteAddedEvent(string aggregateId) : base(aggregateId)
        {
        }

        public override string Type() => "pokemonfavorite.added";
    }
}