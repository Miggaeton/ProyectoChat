using ProyectoChat.Models;

namespace ProyectoChat.Interfaces
{
    public interface INoticiasRepository
    {
        Task<IEnumerable<Noticia>> GetAllAsync();
        Task<Noticia?> GetByIdAsync(Guid id);
        Task AddAsync(Noticia noticia);
        Task UpdateAsync(Noticia noticia);
        Task DeleteAsync(Noticia noticia);
        Task<bool> ExistsAsync(Guid id);
    }
}
