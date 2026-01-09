using Microsoft.AspNetCore.Http;
using ProyectoChat.Models;
using ProyectoChat.Models.Dtos;

namespace ProyectoChat.Interfaces
{
    public interface INoticiasService
    {
        Task<IEnumerable<Noticia>> ObtenerNoticiasAsync();
        Task<Noticia?> ObtenerNoticiaPorIdAsync(Guid id);
        Task<Noticia> CrearNoticiaAsync(NoticiaCreacionDto noticiaDto, Guid userId);
        Task<bool> ActualizarNoticiaAsync(Guid id, NoticiaCreacionDto noticiaDto);
        Task<bool> EliminarNoticiaAsync(Guid id);
    }
}
