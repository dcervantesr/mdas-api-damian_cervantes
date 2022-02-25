using System;
using Pokemon.Pokemon.Domain;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using PokemonNotFoundException = Pokemon.Pokemon.Domain.PokemonNotFoundException;

namespace Pokemon.Pokemon.Infrastructure
{
    public class PokeApiPokemonRepository : IPokemonRepository
    {
        private readonly HttpClient _pokemonClient;
        private const string PokemonUrl = "https://pokeapi.co/api/v2/pokemon/";

        public PokeApiPokemonRepository(HttpClient httpClient)
        {
            _pokemonClient = httpClient;
            _pokemonClient.BaseAddress = new Uri(PokemonUrl);
        }

        public bool Exists(PokemonId pokemonId)
        {
            var exists = ExistsAsync(pokemonId.Value).Result;

            return exists;
        }

        public Domain.Pokemon Find(PokemonId pokemonId)
        {
            var pokemonDto = FindByPokemonIdAsync(pokemonId.Value).Result;

            Domain.Pokemon pokemon = HttpAdapter.PokeApiPokemonDtoToPokemon(pokemonDto);
            return pokemon;
        }

        #region Private Methods

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
                        throw new PokemonNotFoundException();
                    default:
                        throw new PokemonRepositoryIsNotRespondingException();
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
                        throw new PokemonRepositoryIsNotRespondingException();
                }
            }
        }


        #endregion

    }
}
