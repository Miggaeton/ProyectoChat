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
    }
}
