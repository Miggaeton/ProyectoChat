using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoChat.Interfaces;
using ProyectoChat.Models;
using ProyectoChat.Models.Dtos;

namespace ProyectoChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NoticiasController : ControllerBase
    {
        private readonly INoticiasService _noticiasService;
        private readonly ICurrentUserService _currentUserService;

        public NoticiasController(INoticiasService noticiasService, ICurrentUserService currentUserService)
        {
            _noticiasService = noticiasService;
            _currentUserService = currentUserService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Noticia>>> GetNoticias()
        {
            var noticias = await _noticiasService.ObtenerNoticiasAsync();
            return Ok(noticias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Noticia>> GetNoticia(Guid id)
        {
            var noticia = await _noticiasService.ObtenerNoticiaPorIdAsync(id);

            if (noticia == null)
            {
                return NotFound();
            }

            return Ok(noticia);
        }

        [HttpPost]
        public async Task<ActionResult<Noticia>> PostNoticia([FromBody] NoticiaCreacionDto noticiaDto)
        {
            if (!_currentUserService.UserId.HasValue)
            {
                return Unauthorized("No se pudo identificar al usuario.");
            }

            var noticia = await _noticiasService.CrearNoticiaAsync(noticiaDto, _currentUserService.UserId.Value);

            return CreatedAtAction("GetNoticia", new { id = noticia.ID }, noticia);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutNoticia(Guid id, [FromBody] NoticiaCreacionDto noticiaDto)
        {
            var actualizado = await _noticiasService.ActualizarNoticiaAsync(id, noticiaDto);

            if (!actualizado)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNoticia(Guid id)
        {
            var eliminado = await _noticiasService.EliminarNoticiaAsync(id);
            if (!eliminado)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
