using RabbitMQ.Client;

namespace Shared.MessageBroker
{
    public class RabbitHutch
    {
        public static IBus CreateBus(string uri)
        {
            var _factory = new ConnectionFactory() { 
                Uri = new Uri(uri),
                DispatchConsumersAsync = true
            };
            var _connection = _factory.CreateConnection();
            var _channel = _connection.CreateModel();
            return new RabbitMqBus(_channel);
        }
    }
}