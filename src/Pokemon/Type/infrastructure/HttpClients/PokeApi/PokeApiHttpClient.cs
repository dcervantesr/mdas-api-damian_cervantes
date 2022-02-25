using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Pokemon.Type.Domain;

namespace Pokemon.Type.Infrastructure
{
    public class PokeApiHttpClient
    {
        private HttpClient _pokemonClient;
        private string pokemonUrl = "https://pokeapi.co/api/v2/pokemon/";

        public PokeApiHttpClient(HttpClient pokemonClient)
        {
            pokemonClient.BaseAddress = new Uri(pokemonUrl);
            _pokemonClient = pokemonClient;
        }

        public async Task<List<PokeApiTypeDto>> FindByPokemonNameAsync(string pokemonName)
        {
            string url = $"{pokemonName}";
            try
            {
                PokeApiPokemonDto pokemon = await _pokemonClient.GetFromJsonAsync<PokeApiPokemonDto>(url);

                List<PokeApiTypeDto> types = HttpAdapter.PokeApiTypesDtoListToPokeApiTypeDtoList(pokemon.Types);
                return types;
            }
            catch (HttpRequestException e)
            {
                switch (e.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        throw new PokemonNotFoundException();
                    default:
                        throw new TypeRepositoryIsNotRespondingException();
                }
            }

        }
    }
}
