using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoChat.Models
{
    public class Ciudad
    {
        [Key]
        public Guid Id { get; set; }
        public string Nombre { get; set; }

        public Guid DepartamentoId { get; set; }
        [ForeignKey("DepartamentoId")]
        public Departamento Departamento { get; set; }
    }
}