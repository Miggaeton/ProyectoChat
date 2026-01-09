using System.ComponentModel.DataAnnotations;

namespace ProyectoChat.Models
{
    public class Departamento
    {
        [Key]
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        
        // Relación con ciudades
        public ICollection<Ciudad> Ciudades { get; set; }
    }
}