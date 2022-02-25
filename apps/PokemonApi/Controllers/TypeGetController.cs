using Microsoft.AspNetCore.Mvc;
using Pokemon.Type.Application;
using Pokemon.Type.Domain;
using PokemonNotFoundException = Pokemon.Type.Domain.PokemonNotFoundException;

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
        public IActionResult Get(string name)
        {
            if (name == string.Empty)
            {
                return BadRequest("Name is required");
            }
            try
            {
                var getTypesByPokemonNameQuery = TypeGetAdapter.GetByPokemonNameToGetTypesByPokemonNameQuery(name);
                List<Pokemon.Type.Domain.Type> result =
                    _getTypesByPokemonNameUseCase.Execute(getTypesByPokemonNameQuery);

                return Ok(result);
            }
            catch (Exception e)
            {
                if (e is PokemonNotFoundException || (e.InnerException != null && e.InnerException is PokemonNotFoundException))
                    return NotFound(e.InnerException is null ? e.Message : e.InnerException.Message);

                if (e is TypeRepositoryIsNotRespondingException || (e.InnerException != null && e.InnerException is TypeRepositoryIsNotRespondingException))
                    return Conflict(e.InnerException is null ? e.Message : e.InnerException.Message);

                return NotFound("Oops, something has gone wrong. Try again later.");
            }
        }
    }
}
