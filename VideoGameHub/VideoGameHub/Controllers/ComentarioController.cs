using VideoGameHub.Models;
using VideoGameHub.Services;
using Microsoft.AspNetCore.Mvc;

namespace VideoGameHub.Controllers
{
    public class ComentarioController : Controller
    {
        private readonly IComentarioService _service;
        private readonly IVideojuegoService _videojuegoService;

        public ComentarioController(
            IComentarioService service,
            IVideojuegoService videojuegoService)
        {
            _service = service;
            _videojuegoService = videojuegoService;
        }

        [HttpGet]
        [Route("comentario/crear/{videojuegoId}")]
        public IActionResult Crear(int videojuegoId)
        {
            var videojuego = _videojuegoService.ObtenerDetalle(videojuegoId);

            if (videojuego == null)
                return NotFound();

            var model = new ComentarioViewModel
            {
                VideojuegoId = videojuegoId,
                Videojuego = videojuego
            };

            return View(model);
        }

        [HttpPost]
        [Route("comentario/guardar")]
        [ValidateAntiForgeryToken]
        public IActionResult Guardar(ComentarioViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var videojuego = _videojuegoService.ObtenerDetalle(model.VideojuegoId);
                model.Videojuego = videojuego;
                return View("Crear", model);
            }

            _service.CrearComentario(
                model.VideojuegoId,
                model.TextoComentario,
                model.Valoracion);

            return RedirectToAction("Detalle", "Videojuego", new { id = model.VideojuegoId });
        }
    }
}