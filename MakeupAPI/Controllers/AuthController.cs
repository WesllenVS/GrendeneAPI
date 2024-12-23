using MakeupAPI.Dto;
using MakeupAPI.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MakeupAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthInterface _authInterface;

        public AuthController(IAuthInterface authInterface)
        {
            _authInterface = authInterface;
        }


        [HttpPost("login")]
        public async Task<ActionResult> Register(UserLoginDto userLogin)
        {
           var resposta = await _authInterface.Login(userLogin);

            return Ok(resposta);
        }


        [HttpPost("registrar")]
        public async Task<ActionResult> Register(UserCreateDto userRegister)
        {
            var resposta = await _authInterface.Registrar(userRegister);

            return Ok(resposta);
        }
    }
}
