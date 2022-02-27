namespace Shared.MessageBroker
{
    public interface IBus
    {
        Task Publish<T>(string exchangeName, string queue, T @event) where T : DomainEvent;
        Task Publish<T>(string exchangeName, string queue, List<T> events) where T : DomainEvent;
        Task Received<T>(string exchangeName, string queue, string type, Action<T> onMessage) where T : DomainEvent;
    }
}