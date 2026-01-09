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
                new Rol { Id = 5, Nombre = "Director Nacional", Descripcion = "Acceso total al sistema" },
                new Rol { Id = 4, Nombre = "Director Departamental", Descripcion = "Administra departamento" },
                new Rol { Id = 3, Nombre = "Director Municipal", Descripcion = "Administra municipio" },
                new Rol { Id = 2, Nombre = "Líder", Descripcion = "Líder de grupo" },
                new Rol { Id = 1, Nombre = "Usuario", Descripcion = "Usuario básico" }
            );

            modelBuilder.Entity<Departamento>().HasData(
        new Departamento { Id = 1, Nombre = "Amazonas" },
        new Departamento { Id = 2, Nombre = "Antioquia" },
        new Departamento { Id = 3, Nombre = "Arauca" },
        new Departamento { Id = 4, Nombre = "Atlántico" },
        new Departamento { Id = 5, Nombre = "Bolívar" },
        new Departamento { Id = 6, Nombre = "Boyacá" },
        new Departamento { Id = 7, Nombre = "Caquetá" },
        new Departamento { Id = 8, Nombre = "Caldas" },
        new Departamento { Id = 9, Nombre = "Casanare" },
        new Departamento { Id = 10, Nombre = "Cauca" },
        new Departamento { Id = 11, Nombre = "Cesar" },
        new Departamento { Id = 12, Nombre = "Chocó" },
        new Departamento { Id = 13, Nombre = "Córdoba" },
        new Departamento { Id = 14, Nombre = "Norte de Santander" },
        new Departamento { Id = 15, Nombre = "Cundinamarca" },
        new Departamento { Id = 16, Nombre = "Guainía" },
        new Departamento { Id = 17, Nombre = "Guaviare" },
        new Departamento { Id = 18, Nombre = "Huila" },
        new Departamento { Id = 19, Nombre = "La Guajira" },
        new Departamento { Id = 20, Nombre = "Magdalena" },
        new Departamento { Id = 21, Nombre = "Meta" },
        new Departamento { Id = 22, Nombre = "Nariño" },
        new Departamento { Id = 23, Nombre = "Putumayo" },
        new Departamento { Id = 24, Nombre = "Quindío" },
        new Departamento { Id = 25, Nombre = "Risaralda" },
        new Departamento { Id = 26, Nombre = "San Andrés" },
        new Departamento { Id = 27, Nombre = "Santander" },
        new Departamento { Id = 28, Nombre = "Sucre" },
        new Departamento { Id = 29, Nombre = "Tolima" },
        new Departamento { Id = 30, Nombre = "Valle del Cauca" },
        new Departamento { Id = 31, Nombre = "Vaupés" },
        new Departamento { Id = 32, Nombre = "Vichada" }
    );

    modelBuilder.Entity<Ciudad>().HasData(
        new Ciudad { Id = 1, Nombre = "Cartagena", DepartamentoId = 5 },
        new Ciudad { Id = 2, Nombre = "Cúcuta", DepartamentoId = 14 },
        new Ciudad { Id = 3, Nombre = "San Andrés, Prov. y Santa Catalina", DepartamentoId = 26 },
        new Ciudad { Id = 4, Nombre = "Valledupar", DepartamentoId = 11 },
        new Ciudad { Id = 5, Nombre = "Bogotá", DepartamentoId = 15 }
    );
        }
    }
}
