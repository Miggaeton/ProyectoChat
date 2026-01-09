    namespace ProyectoChat.Models
{
    public class Usuario
    {
        public Guid ID {  get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int Estado { get; set; }
        public string RolId { get; set; }
        public Rol Rol { get; set; }
        public Guid? JefeID { get; set; }
        public Usuario? Jefe { get; set; }
        public Guid? FormExternoID { get; set; }
    }
}
