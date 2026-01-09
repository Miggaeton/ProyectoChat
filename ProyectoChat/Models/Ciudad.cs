using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoChat.Models
{
    public class Ciudad
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }

        public int DepartamentoId { get; set; }
        [ForeignKey("DepartamentoId")]
        public Departamento Departamento { get; set; }
    }
}