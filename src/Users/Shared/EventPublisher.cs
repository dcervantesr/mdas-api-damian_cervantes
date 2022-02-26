namespace Users.Shared
{
    public interface EventPublisher
    {
        void Publish<T>(T @event) where T : DomainEvent;
        void Publish<T>(List<T> events) where T : DomainEvent;
    }
}