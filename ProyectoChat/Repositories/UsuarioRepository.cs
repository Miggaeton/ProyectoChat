using Microsoft.EntityFrameworkCore;
using ProyectoChat.Context;
using ProyectoChat.Interfaces;
using ProyectoChat.Models;

namespace ProyectoChat.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly OrgDbContext _context;

        public UsuarioRepository(OrgDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Usuario?> GetByIdAsync(Guid id)
        {
            return await _context.Usuarios.FindAsync(id);
        }
    }
}
