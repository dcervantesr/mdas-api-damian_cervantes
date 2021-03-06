using Microsoft.AspNetCore.Mvc;
using Pokemon.Type.Application;
using Pokemon.Type.Domain;
using PokemonNotFound = Pokemon.Type.Domain.PokemonNotFound;

namespace PokemonApi.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class TypeGetController : ControllerBase
    {
        private readonly GetTypesByPokemonNameUseCase _getTypesByPokemonNameUseCase;

        public TypeGetController(GetTypesByPokemonNameUseCase getTypesByPokemonNameUseCase)
        {
            _getTypesByPokemonNameUseCase = getTypesByPokemonNameUseCase;
        }

        [HttpGet("type/{name}")]
        public IActionResult Get(string pokemonName)
        {
            if (string.IsNullOrEmpty(pokemonName))
            {
                return BadRequest("Name is required");
            }
            try
            {
                return Ok(_getTypesByPokemonNameUseCase.Execute(pokemonName));
            }
            catch (Exception e)
            {
                if (e is PokemonNotFound || (e.InnerException != null && e.InnerException is PokemonNotFound))
                    return NotFound(e.InnerException is null ? e.Message : e.InnerException.Message);

                if (e is TypeRepositoryIsNotResponding || (e.InnerException != null && e.InnerException is TypeRepositoryIsNotResponding))
                    return Conflict(e.InnerException is null ? e.Message : e.InnerException.Message);

                return NotFound("Oops, something has gone wrong. Try again later.");
            }
        }
    }
}
