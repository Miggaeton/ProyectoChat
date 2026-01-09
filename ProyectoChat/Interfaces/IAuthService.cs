using ProyectoChat.Models;
using ProyectoChat.Models.Dtos;

namespace ProyectoChat.Interfaces
{
    public interface IAuthService
    {
        Task<Usuario?> AutenticarUsuarioAsync(string email);
        string GenerateJwtToken(Usuario usuario);
        Task<Usuario> CreateUserAsync(CreateUserDto createUserDto);
    }
}
