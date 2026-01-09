using ProyectoChat.Interfaces;
using ProyectoChat.Models;
using ProyectoChat.Models.Dtos;
using ProyectoChat.Repositories;

namespace ProyectoChat.Services
{
    public class NoticiasService : INoticiasService
    {
        private readonly INoticiasRepository _noticiasRepository;
        private readonly IWebHostEnvironment _environment;

        public NoticiasService(INoticiasRepository noticiasRepository, IWebHostEnvironment environment)
        {
            _noticiasRepository = noticiasRepository;
            _environment = environment;
        }

        public async Task<IEnumerable<Noticia>> ObtenerNoticiasAsync()
        {
            return await _noticiasRepository.GetAllAsync();
        }

        public async Task<Noticia?> ObtenerNoticiaPorIdAsync(Guid id)
        {
            return await _noticiasRepository.GetByIdAsync(id);
        }

        public async Task<Noticia> CrearNoticiaAsync(NoticiaCreacionDto noticiaDto, Guid userId)
        {
            var noticia = new Noticia
            {
                ID = Guid.NewGuid(),
                Titulo = noticiaDto.Titulo,
                Descripcion = noticiaDto.Descripcion,
                FechaPublicacion = DateTime.UtcNow,
                CreadorID = userId,
                ImagenURL = noticiaDto.ImagenURL ?? ""
            };

            await ProcesarImagenAsync(noticia, noticiaDto.ImagenArchivo);

            await _noticiasRepository.AddAsync(noticia);
            return noticia;
        }

        public async Task<bool> ActualizarNoticiaAsync(Guid id, NoticiaCreacionDto noticiaDto)
        {
            var noticia = await _noticiasRepository.GetByIdAsync(id);
            if (noticia == null)
            {
                return false;
            }

            noticia.Titulo = noticiaDto.Titulo;
            noticia.Descripcion = noticiaDto.Descripcion;

            if (noticiaDto.ImagenURL != null)
            {
                noticia.ImagenURL = noticiaDto.ImagenURL;
            }

            await ProcesarImagenAsync(noticia, noticiaDto.ImagenArchivo);

            await _noticiasRepository.UpdateAsync(noticia);
            return true;
        }

        public async Task<bool> EliminarNoticiaAsync(Guid id)
        {
            var noticia = await _noticiasRepository.GetByIdAsync(id);
            if (noticia == null)
            {
                return false;
            }

            await _noticiasRepository.DeleteAsync(noticia);
            return true;
        }

        private async Task ProcesarImagenAsync(Noticia noticia, IFormFile? imagenArchivo)
        {
            if (imagenArchivo != null)
            {
                string wwwRootPath = _environment.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imagenArchivo.FileName);
                string uploadsFolder = Path.Combine(wwwRootPath, "imagenes", "noticias");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string filePath = Path.Combine(uploadsFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imagenArchivo.CopyToAsync(fileStream);
                }

                noticia.ImagenURL = $"/imagenes/noticias/{fileName}";
            }
        }
    }
}
