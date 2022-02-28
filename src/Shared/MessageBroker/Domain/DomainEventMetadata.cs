namespace Shared.MessageBroker
{
    public class DomainEventMetadata
    {
        public string AggregateId { get; set; }

        public DomainEventMetadata(string aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}