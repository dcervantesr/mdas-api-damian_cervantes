namespace Shared.MessageBroker
{
    public abstract class DomainEvent
    {
        public string AggregateId { get; }
        public DomainEventMetadata? Metadata { get; }
        public string Type { get; }

        public DomainEvent(
            string aggregateId, 
            DomainEventMetadata? metadata, 
            string type)
        {
            this.AggregateId = aggregateId;
            this.Metadata = metadata;
            this.Type = type;
        }
    }
}