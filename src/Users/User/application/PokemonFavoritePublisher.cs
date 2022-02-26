using System.Text;
using RabbitMQ.Client;

namespace Users.User.Application
{
    public class PokemonFavoritePublisher
    {
        public void Publish(int PokemonId)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.UserName = "netcoders";
            factory.Password = "netcoders";
            factory.VirtualHost = "netcoders";
            factory.HostName = "localhost";
            factory.Port = 5672;
            IConnection conn = factory.CreateConnection();
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var body = Encoding.UTF8.GetBytes(PokemonId.ToString());
                channel.QueueDeclare(queue: "pokemon_favorite",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                channel.BasicPublish(exchange: "domain_events",
                                     routingKey: "pokemon_favorite",
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}