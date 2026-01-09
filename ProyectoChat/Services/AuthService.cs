using Microsoft.IdentityModel.Tokens;
using ProyectoChat.Interfaces;
using ProyectoChat.Models;
using ProyectoChat.Models.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProyectoChat.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _configuration;
        private readonly ProyectoChat.Context.OrgDbContext _context;

        public AuthService(IUsuarioRepository usuarioRepository, IConfiguration configuration, ProyectoChat.Context.OrgDbContext context)
        {
            _usuarioRepository = usuarioRepository;
            _configuration = configuration;
            _context = context;
        }

        public async Task<Usuario?> AutenticarUsuarioAsync(string email)
        {
            return await _usuarioRepository.GetByEmailAsync(email);
        }

        public async Task<Usuario> CreateUserAsync(CreateUserDto createUserDto)
        {
            if (createUserDto.RolId != 1 && string.IsNullOrEmpty(createUserDto.Password))
            {
                throw new ArgumentException("La contraseña es obligatoria para todos los roles excepto el rol 5");
            }

            string? passwordHash = null;
            if (!string.IsNullOrEmpty(createUserDto.Password))
            {
                passwordHash = BCrypt.Net.BCrypt.HashPassword(createUserDto.Password);
            }

            var usuario = new Usuario
            {
                Nombre = createUserDto.Nombre,
                Telefono = createUserDto.Telefono,
                Email = createUserDto.Email,
                Estado = createUserDto.Estado,
                RolId = createUserDto.RolId,
                JefeID = createUserDto.JefeID,
                FormExternoID = createUserDto.FormExternoID,
                PasswordHash = passwordHash
            };

            // Lógica de búsqueda de ubicación por Nombre
            if (!string.IsNullOrEmpty(createUserDto.Lugar))
            {
                var ciudad = await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(_context.Ciudades, c => c.Nombre.ToLower() == createUserDto.Lugar.ToLower());
                
                if (ciudad != null)
                {
                    usuario.CiudadId = ciudad.Id;
                    usuario.DepartamentoId = ciudad.DepartamentoId;
                }
                else
                {
                    var departamento = await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(_context.Departamentos, d => d.Nombre.ToLower() == createUserDto.Lugar.ToLower());
                    if (departamento != null)
                    {
                        usuario.DepartamentoId = departamento.Id;
                    }
                }
            }

            return await _usuarioRepository.AddAsync(usuario);
        }

        public string GenerateJwtToken(Usuario usuario)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? "ClaveSecretaSuperSeguraParaElProyectoChat123"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("guid", usuario.ID.ToString()),
                new Claim(ClaimTypes.Role, usuario.RolId.ToString()),
                new Claim(ClaimTypes.NameIdentifier, usuario.ID.ToString()),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Name, usuario.Nombre)
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
