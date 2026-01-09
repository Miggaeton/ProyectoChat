using Microsoft.AspNetCore.Mvc;
using ProyectoChat.Models.Body;

namespace ProyectoChat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginBody command) { 
        
            throw new NotImplementedException();
        }
    }
}
