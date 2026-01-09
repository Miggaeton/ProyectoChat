using ProyectoChat.Models;

namespace ProyectoChat.Interfaces
{
    public interface IAuthService
    {
        Task<Usuario?> AutenticarUsuarioAsync(string email);
        string GenerateJwtToken(Usuario usuario);
    }
}
