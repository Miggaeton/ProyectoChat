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
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Rol)
                .WithMany()
                .HasForeignKey(u => u.RolId);

            modelBuilder.Entity<Rol>().HasData(
                new Rol { Id = 1, Nombre = "National Director", Descripcion = "Acceso total al sistema" },
                new Rol { Id = 2, Nombre = "Department Director", Descripcion = "Administra departamento" },
                new Rol { Id = 3, Nombre = "Municipal Director", Descripcion = "Administra municipio" },
                new Rol { Id = 4, Nombre = "Leader", Descripcion = "Líder de grupo" },
                new Rol { Id = 5, Nombre = "User", Descripcion = "Usuario básico" }
            );
        }
    }
}
