using Microsoft.AspNetCore.Mvc;
using ProyectoChat.Interfaces;
using ProyectoChat.Models.Dtos;

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

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            try
            {
                await _authService.CreateUserAsync(createUserDto);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno al crear usuario: " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var usuario = await _authService.AutenticarUsuarioAsync(loginDto.Email);

            if (usuario == null)
            {
                return Unauthorized("Usuario no encontrado.");
            }

            // Validación de contraseña para todos los roles excepto Rol 5
            if (usuario.RolId != 5)
            {
                if (string.IsNullOrEmpty(loginDto.Password) || string.IsNullOrEmpty(usuario.PasswordHash) || !BCrypt.Net.BCrypt.Verify(loginDto.Password, usuario.PasswordHash))
                {
                    return Unauthorized("Contraseña incorrecta.");
                }
            }

            var token = _authService.GenerateJwtToken(usuario);

            return Ok(new 
            { 
                token, 
                nombre = usuario.Nombre, 
                rolId = usuario.RolId 
            });
        }
    }

    public class LoginDto
    {
        public string Email { get; set; }
        public string? Password { get; set; }
    }
}
