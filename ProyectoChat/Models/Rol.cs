using System.ComponentModel.DataAnnotations;

namespace ProyectoChat.Models
{
    public class Rol
    {
        [Key]
        public int Id { get; set; } // national, department, etc.
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}