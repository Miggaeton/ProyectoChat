using Microsoft.EntityFrameworkCore;
using ProyectoChat.Context;
using ProyectoChat.Interfaces;
using ProyectoChat.Models;

namespace ProyectoChat.Repositories
{
    public class NoticiasRepository : INoticiasRepository
    {
        private readonly OrgDbContext _context;

        public NoticiasRepository(OrgDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Noticia>> GetAllAsync()
        {
            return await _context.Noticias.Include(n => n.Creador).ToListAsync();
        }

        public async Task<Noticia?> GetByIdAsync(Guid id)
        {
            return await _context.Noticias.Include(n => n.Creador).FirstOrDefaultAsync(n => n.ID == id);
        }

        public async Task AddAsync(Noticia noticia)
        {
            _context.Noticias.Add(noticia);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Noticia noticia)
        {
            _context.Entry(noticia).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Noticia noticia)
        {
            _context.Noticias.Remove(noticia);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _context.Noticias.AnyAsync(e => e.ID == id);
        }
    }
}
