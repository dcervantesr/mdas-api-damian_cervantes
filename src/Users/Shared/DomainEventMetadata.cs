namespace Users.Shared
{
    public class DomainEventMetadata
    {
        public string AggregateId { get; set; }
        public DateTime OccurredOn = DateTime.Now;

        public DomainEventMetadata(string aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}