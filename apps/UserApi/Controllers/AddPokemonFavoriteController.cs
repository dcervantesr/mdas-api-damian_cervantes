using Microsoft.AspNetCore.Mvc;
using Users.User.Application;
using UserApi.Dto;

namespace UserApi.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class AddPokemonFavoriteController : ControllerBase
    {

        private readonly AddPokemonFavoriteUseCase _addPokemonFavoriteUseCase;

        public AddPokemonFavoriteController(
            AddPokemonFavoriteUseCase addPokemonFavoriteUseCase
        )
        {
            _addPokemonFavoriteUseCase = addPokemonFavoriteUseCase;
        }

        [HttpPost("users/pokemonfavorite")]
        public IActionResult AddPokemonFavorite([FromBody] AddPokemonFavoriteDto addPokemonFavoriteDto)
        {
            try
            {
                _addPokemonFavoriteUseCase.Execute(addPokemonFavoriteDto.UserId, addPokemonFavoriteDto.PokemonId);
                return Ok();
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
    }
}