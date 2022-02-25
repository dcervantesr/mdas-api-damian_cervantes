using Microsoft.AspNetCore.Mvc;
using Pokemon.Pokemon.Application;
using Pokemon.Pokemon.Domain;

namespace PokemonApi.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class PokemonGetController : ControllerBase
    {
        private readonly GetPokemonByPokemonIdUseCase _getPokemonByPokemonIdUseCase;

        public PokemonGetController(GetPokemonByPokemonIdUseCase getPokemonByPokemonIdUseCase)
        {
            _getPokemonByPokemonIdUseCase = getPokemonByPokemonIdUseCase;
        }

        [HttpGet("pokemon/{id:int}")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Oops, something has gone wrong with request. Correct your call and try again");
            }
            try
            {
                Pokemon.Pokemon.Domain.Pokemon pokemon = _getPokemonByPokemonIdUseCase.Execute(id);
                var pokemonDto = PokemonGetAdapter.PokemonToGetPokemonDto(pokemon);

                return Ok(pokemonDto);
            }
            catch (Exception e)
            {
                if (e is PokemonNotFoundException || (e.InnerException != null && e.InnerException is PokemonNotFoundException))
                {
                    return NotFound(e.InnerException is null ? e.Message : e.InnerException.Message);
                }
                if (e is PokemonRepositoryIsNotRespondingException || (e.InnerException != null && e.InnerException is PokemonRepositoryIsNotRespondingException))
                    return Conflict(e.InnerException is null ? e.Message : e.InnerException.Message);

                return NotFound("Oops, something has gone wrong. Try again later.");
            }
        }
    }
}
