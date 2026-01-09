namespace ProyectoChat.Models
{
    public class Noticia
    {
        public Guid ID { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string ImagenURL { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public Guid CreadorID { get; set; }
        public Usuario Creador {  get; set; }
    }
}
