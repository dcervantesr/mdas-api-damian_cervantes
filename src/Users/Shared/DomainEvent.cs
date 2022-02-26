namespace Users.Shared
{
    public abstract class DomainEvent
    {
        private string aggregateId;
        public DomainEventMetadata Metadata;

        public DomainEvent(string aggregateId)
        {
            this.aggregateId = aggregateId;
            this.Metadata = new DomainEventMetadata(aggregateId);
        }

        abstract public string Type();
    }
}