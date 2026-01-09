using Microsoft.AspNetCore.Mvc;
using ProyectoChat.Interfaces;

namespace ProyectoChat.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IAuthService _authService;

        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var usuario = await _authService.AutenticarUsuarioAsync(loginDto.Email);

            if (usuario == null)
            {
                return Unauthorized("Usuario no encontrado.");
            }

            var token = _authService.GenerateJwtToken(usuario);

            return Ok(new { token });
        }
    }

    public class LoginDto
    {
        public string Email { get; set; }
    }
}
