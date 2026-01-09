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
            return await _context.Usuarios
                .Include(u => u.Rol)
                .Include(u => u.Departamento)
                .Include(u => u.Ciudad)
                .Include(u => u.Jefe)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Usuario?> GetByIdAsync(Guid id)
        {
            return await _context.Usuarios
                .Include(u => u.Rol)
                .Include(u => u.Departamento)
                .Include(u => u.Ciudad)
                .Include(u => u.Jefe)
                .FirstOrDefaultAsync(u => u.ID == id);
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios
                .Include(u => u.Rol)
                .Include(u => u.Departamento)
                .Include(u => u.Ciudad)
                .Include(u => u.Jefe)
                .ToListAsync();
        }

        public async Task<Usuario> AddAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
    }
}
