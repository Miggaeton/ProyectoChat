using Microsoft.EntityFrameworkCore;
using ProyectoChat.Models;
using System;

namespace ProyectoChat.Context
{
    public class OrgDbContext : DbContext
    {
        public OrgDbContext(DbContextOptions<OrgDbContext> options)
            : base(options)
                {
                }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Noticia> Noticias { get; set; }
        public DbSet<Rol> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Rol)
                .WithMany()
                .HasForeignKey(u => u.RolId);

            modelBuilder.Entity<Rol>().HasData(
                new Rol { Id = "national", Nombre = "National Director", Descripcion = "Acceso total al sistema" },
                new Rol { Id = "department", Nombre = "Department Director", Descripcion = "Administra departamento" },
                new Rol { Id = "municipal", Nombre = "Municipal Director", Descripcion = "Administra municipio" },
                new Rol { Id = "leader", Nombre = "Leader", Descripcion = "Líder de grupo" },
                new Rol { Id = "user", Nombre = "User", Descripcion = "Usuario básico" }
            );
        }
    }
}
