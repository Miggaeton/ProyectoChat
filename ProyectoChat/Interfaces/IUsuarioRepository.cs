using ProyectoChat.Models;

namespace ProyectoChat.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> GetByEmailAsync(string email);
        Task<Usuario?> GetByIdAsync(Guid id);
        // Add other methods as needed
    }
}
