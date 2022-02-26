using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace Users.Shared
{
    public class RabbitMqEventPublisher : EventPublisher
    {
        public RabbitMqEventPublisher()
        { }

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
            var factory = new ConnectionFactory() { 
                HostName = "localhost",
                Port = 5672,
                UserName = "netcoders",
                Password = "netcoders",
                VirtualHost = "netcoders"
            };

            using var connection = factory.CreateConnection();
            using var _channel = connection.CreateModel();
            _channel.QueueDeclare(queue: "netcoders",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(@event));
            var properties = _channel.CreateBasicProperties();
            properties.Type = @event.Type();
            _channel.BasicPublish(
                exchange: "domain_events",
                routingKey: @event.Type(),
                basicProperties: properties,
                body: body
            );
        }
    }
}
