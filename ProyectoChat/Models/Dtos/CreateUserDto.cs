namespace ProyectoChat.Models.Dtos
{
    public class CreateUserDto
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int Estado { get; set; }
        public int RolId { get; set; }
        public string Lugar { get; set; }

        public Guid? JefeID { get; set; }
        public Guid? FormExternoID { get; set; }
        public string? Password { get; set; }
    }
}
