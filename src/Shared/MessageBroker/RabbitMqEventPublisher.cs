using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace Shared.MessageBroker
{
    public class RabbitMqEventPublisher : EventPublisher
    {
        public void Publish<T>(T @event) where T : DomainEvent => SendEvent(@event);

        public void Publish<T>(List<T> events) where T : DomainEvent
        {
            foreach (var @event in events)
            {
                SendEvent(@event);
            }
        }

        private void SendEvent<T>(T @event) where T : DomainEvent
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri("amqp://netcoders:netcoders@localhost:5672/netcoders");
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.ExchangeDeclare("domain_events", ExchangeType.Direct);
            channel.QueueDeclare("favorites", false, false, false, null);
            channel.QueueBind("favorites", "domain_events", @event.Type(), null);
            byte[] messageBodyBytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(@event.Metadata));
            var properties = channel.CreateBasicProperties();
            properties.Type = @event.Type();
            channel.BasicPublish("domain_events", @event.Type(), properties, messageBodyBytes);
            channel.Close();
            connection.Close();
        }
    }
}
