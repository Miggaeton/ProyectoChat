using Microsoft.AspNetCore.Mvc;
using ProyectoChat.Models.Body;

namespace ProyectoChat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoticiaController : Controller
    {
        [HttpPost("create")]
        public async Task<IActionResult> CrearNoticia([FromBody] LoginBody command)
        {

            throw new NotImplementedException();
        }

        [HttpGet("get")]
        public async Task<IActionResult> ObtenerNoticia([FromQuery] Guid NoticiaID)
        {

            throw new NotImplementedException();
        }

        [HttpGet("list")]
        public async Task<IActionResult> ListarNoticias([FromQuery] int pagina, int tamano)
        {

            throw new NotImplementedException();
        }
    }
}
    
