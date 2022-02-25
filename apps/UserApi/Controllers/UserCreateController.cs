using Microsoft.AspNetCore.Mvc;
using Users.User.Application;
using UserApi.Dto;

namespace UserApi.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class UserCreateController : ControllerBase
    {

        private readonly CreateUserUseCase _createUserUseCase;

        public UserCreateController(
            CreateUserUseCase createUserUseCase
        )
        {
            _createUserUseCase = createUserUseCase;
        }

        [HttpPost("users")]
        public IActionResult CreateUser([FromBody]UserCreatorDto userCreatorDto)
        {
            if (string.IsNullOrEmpty(userCreatorDto.Name))
            {
                return BadRequest();
            }
            try
            {
               _createUserUseCase.Execute(userCreatorDto.Id, userCreatorDto.Name);
                return Ok();
            }
            catch(Exception e)
            {
                return Conflict(e.Message);
            }
        }
    }
}