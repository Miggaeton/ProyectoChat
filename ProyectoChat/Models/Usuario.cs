    namespace ProyectoChat.Models
{
    public class Usuario
    {
        public Guid ID {  get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string? PasswordHash { get; set; }
        public int Estado { get; set; }
        public int RolId { get; set; }
        public Rol Rol { get; set; }
        public Guid? JefeID { get; set; }
        public Usuario? Jefe { get; set; }
        public int? DepartamentoId { get; set; }
        public Departamento? Departamento { get; set; }
        public int? CiudadId { get; set; }
        public Ciudad? Ciudad { get; set; }
        public Guid? FormExternoID { get; set; }
    }
}
