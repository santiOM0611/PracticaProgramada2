using VideoGameHub.Models;
using VideoGameHub.Services;
using Microsoft.AspNetCore.Mvc;

namespace VideoGameHub.Controllers
{
    [Route("videojuego")]
    public class VideojuegoController : Controller
    {
        private readonly IVideojuegoService _videojuegoService;
        private readonly IDesarrolladorService _desarrolladorService;

        public VideojuegoController(
            IVideojuegoService videojuegoService,
            IDesarrolladorService desarrolladorService)
        {
            _videojuegoService = videojuegoService;
            _desarrolladorService = desarrolladorService;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var videojuegos = _videojuegoService.ObtenerTodos();
            return View(videojuegos);
        }

        [HttpGet("detalle/{id:int}")]
        public IActionResult Detalle(int id)
        {
            var videojuego = _videojuegoService.ObtenerDetalle(id);

            if (videojuego == null)
                return NotFound();

            return View(videojuego);
        }

        [HttpGet("crear")]
        public IActionResult Crear()
        {
            ViewBag.Desarrolladores = _desarrolladorService.ObtenerTodos();
            return View(new VideojuegoViewModel());
        }

        [HttpPost("crear")]
        public IActionResult Crear(VideojuegoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Desarrolladores = _desarrolladorService.ObtenerTodos();
                return View(model);
            }

            var videojuego = new Videojuego
            {
                Titulo = model.Titulo,
                Genero = model.Genero,
                Plataforma = model.Plataforma,
                Precio = model.Precio,
                DesarrolladorId = model.DesarrolladorId,
                ImagenUrl = _videojuegoService.GuardarImagen(model.Imagen)
            };

            _videojuegoService.CrearVideojuego(videojuego);

            return RedirectToAction("Index");
        }

        [HttpGet("editar/{id:int}")]
        public IActionResult Editar(int id)
        {
            var videojuego = _videojuegoService.ObtenerDetalle(id);

            if (videojuego == null)
                return NotFound();

            ViewBag.Desarrolladores = _desarrolladorService.ObtenerTodos();
            return View(videojuego);
        }

        [HttpPost("editar/{id:int}")]
        public IActionResult Editar(int id, Videojuego videojuego)
        {
            if (id != videojuego.Id)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                ViewBag.Desarrolladores = _desarrolladorService.ObtenerTodos();
                return View(videojuego);
            }

            _videojuegoService.ActualizarVideojuego(videojuego);

            return RedirectToAction("Index");
        }

        [HttpPost("eliminar/{id:int}")]
        public IActionResult Eliminar(int id)
        {
            _videojuegoService.EliminarVideojuego(id);
            return RedirectToAction("Index");
        }
    }
}