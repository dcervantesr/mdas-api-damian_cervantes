using System;
using System.Text;
using System.Text.Json;
using Pokemon.Pokemon.Application;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Shared.MessageBroker;
namespace Pokemon.Pokemon.Infrastructure
{
    public class NotifyPokemonAddAsFavoriteSubscriber
    {
        private readonly PokemonAddAsFavoriteUseCase _pokemonAddAsFavoriteUseCase;

        public NotifyPokemonAddAsFavoriteSubscriber(
            PokemonAddAsFavoriteUseCase pokemonAddAsFavoriteUseCase
        )
        {
            _pokemonAddAsFavoriteUseCase = pokemonAddAsFavoriteUseCase;
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri("amqp://netcoders:netcoders@localhost:5672/netcoders");
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.ExchangeDeclare("domain_events", ExchangeType.Direct);
            var queueName = channel.QueueDeclare().QueueName;
            channel.QueueBind(queueName, "domain_events", "pokemonfavorite.added");
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var metadata = JsonSerializer.Deserialize<DomainEventMetadata>(message);
                _pokemonAddAsFavoriteUseCase.Execute(int.Parse(metadata.AggregateId));
            };
            channel.BasicConsume(queueName, autoAck: true, consumer);     
            channel.Close();
            connection.Close();
        }
    }
}