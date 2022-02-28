using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Shared.MessageBroker
{
    public class RabbitMqBus : IBus
    {
        private readonly IModel _channel;

        public RabbitMqBus(IModel channel)
        {
            _channel = channel;
        }
        
        public async Task Publish<T>(string exchangeName, string queue, T @event) where T : DomainEvent => await SendEvent(exchangeName, queue, @event);
        
        public async Task Publish<T>(string exchangeName, string queue, List<T> events) where T : DomainEvent
        {
            foreach (var @event in events)
            {
                await SendEvent(exchangeName, queue, @event);
            }
        }
        
        public async Task Received<T>(string exchangeName, string queue, string type, Action<T> onMessage) where T : DomainEvent
        {
            _channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
            _channel.QueueDeclare(queue, true, false, false, null);
            _channel.QueueBind(queue, exchangeName, type, null);
            var consumer = new AsyncEventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                var json = Encoding.UTF8.GetString(ea.Body.Span);
                var item = JsonSerializer.Deserialize<T>(json);
                onMessage(item);
                await Task.Yield();
            };
            _channel.BasicConsume(queue, true, consumer);
            await Task.Yield();
        }


        private async Task SendEvent<T>(string exchangeName, string queue, T @event) where T : DomainEvent
        {
            await Task.Run(() => {
                _channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
                _channel.QueueDeclare(queue, true, false, false, null);
                _channel.QueueBind(queue, exchangeName, @event.Type, null);
                IBasicProperties properties = _channel.CreateBasicProperties();
                properties.Type = @event.Type;
                byte[] output = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(@event));
                _channel.BasicPublish(exchangeName, @event.Type, properties, output);
            });
        }
    }
}
