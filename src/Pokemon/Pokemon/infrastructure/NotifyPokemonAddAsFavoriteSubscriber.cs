using Pokemon.Pokemon.Application;
using Shared.MessageBroker;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Threading;

namespace Pokemon.Pokemon.Infrastructure
{
    public class NotifyPokemonAddAsFavoriteSubscriber : BackgroundService
    {
        private readonly ILogger<NotifyPokemonAddAsFavoriteSubscriber> _logger;
        private readonly IBus _busControl;
        private readonly AddPokemonAsFavoriteUseCase _addPokemonAsFavoriteUseCase;

        public NotifyPokemonAddAsFavoriteSubscriber(
            ILogger<NotifyPokemonAddAsFavoriteSubscriber> logger,
            IBus busControl,
            AddPokemonAsFavoriteUseCase pokemonAddAsFavoriteUseCase
        )
        {
            _logger = logger;
            _busControl = busControl;
            _addPokemonAsFavoriteUseCase = pokemonAddAsFavoriteUseCase;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("NotifyPokemonAddAsFavoriteSubscriber is running.");
            await _busControl.Received<PokemonFavoriteAddedEvent>(
                Exchange.DomainEvents,
                Queue.Favorites,
                "pokemonfavorite.added",
                message =>
                {
                    Task.Run(() => { DidJob(message); }, stoppingToken);
                }
            );
        }

        private void DidJob(PokemonFavoriteAddedEvent message)
        {
            _logger.LogInformation("NotifyPokemonAddAsFavoriteSubscriber received a message.");
            _addPokemonAsFavoriteUseCase.Execute(int.Parse(message.AggregateId));
        }
    }
}