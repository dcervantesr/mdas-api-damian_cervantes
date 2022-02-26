using System;
using Pokemon.Pokemon.Domain;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using PokemonNotFound = Pokemon.Pokemon.Domain.PokemonNotFound;

namespace Pokemon.Pokemon.Infrastructure
{
    public class PokeApiPokemonRepository : IPokemonRepository
    {
        private readonly HttpClient _pokemonClient;
        private readonly PokemonAdapter _pokemonAdapter;
        private const string PokemonUrl = "https://pokeapi.co/api/v2/pokemon/";
        private readonly MemoryPokemonRepository _memoryPokemonRepository;

        public PokeApiPokemonRepository(
            HttpClient httpClient,
            PokemonAdapter pokemonAdapter,
            MemoryPokemonRepository memoryPokemonRepository
        )
        {
            _pokemonClient = httpClient;
            _pokemonClient.BaseAddress = new Uri(PokemonUrl);
            _pokemonAdapter = pokemonAdapter;
            _memoryPokemonRepository = memoryPokemonRepository;
        }

        public bool Exists(PokemonId pokemonId)
        {
            var exists = ExistsAsync(pokemonId.Value).Result;

            return exists;
        }

        public Domain.Pokemon Find(PokemonId pokemonId)
        {
            var pokemonDto = FindByPokemonIdAsync(pokemonId.Value).Result;

            Domain.Pokemon pokemon = _pokemonAdapter.PokeApiPokemonDtoToPokemon(pokemonDto);
            return pokemon;
        }

        public void Save(Domain.Pokemon pokemon)
        {
            _memoryPokemonRepository.Save(pokemon.PokemonId.Value, pokemon.PokemonFavoriteCounter.Value);
        }

        private async Task<PokeApiPokemonDto> FindByPokemonIdAsync(int pokemonId)
        {
            string url = $"{pokemonId}";
            try
            {
                PokeApiPokemonDto pokemon = await _pokemonClient.GetFromJsonAsync<PokeApiPokemonDto>(url);

                return pokemon;
            }
            catch (HttpRequestException e)
            {
                switch (e.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        throw new PokemonNotFound();
                    default:
                        throw new PokemonRepositoryIsNotResponding();
                }
            }

        }
        private async Task<bool> ExistsAsync(int pokemonId)
        {
            string url = $"{pokemonId}";
            try
            {
                PokeApiPokemonDto pokemon = await _pokemonClient.GetFromJsonAsync<PokeApiPokemonDto>(url);

                return true;
            }
            catch (HttpRequestException e)
            {
                switch (e.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return false;
                    default:
                        throw new PokemonRepositoryIsNotResponding();
                }
            }
        }
    }
}
