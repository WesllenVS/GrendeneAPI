using MakeupAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MakeupAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public ActionResult<ResponseModel<string>> GetUsuario()
        {
            ResponseModel<string> resposta = new ResponseModel<string>();

            resposta.Mensagem = "Acessado";

            return Ok(resposta);
        }

    }
}
