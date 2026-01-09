namespace ProyectoChat.Models
{
    public class Municipio
    {
        public Guid ID { get; set; }
        public string Nombre { get; set; }
        public Guid DepartamentoID { get; set; }
        public Departamento Departamento { get; set; }
    }
}
