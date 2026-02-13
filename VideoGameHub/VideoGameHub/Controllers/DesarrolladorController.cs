using VideoGameHub.Models;
using VideoGameHub.Services;
using Microsoft.AspNetCore.Mvc;

namespace VideoGameHub.Controllers
{
    [Route("desarrollador")]
    public class DesarrolladorController : Controller
    {
        private readonly IDesarrolladorService _desarrolladorService;

        public DesarrolladorController(IDesarrolladorService desarrolladorService)
        {
            _desarrolladorService = desarrolladorService;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var desarrolladores = _desarrolladorService.ObtenerTodos();
            return View(desarrolladores);
        }

        [HttpGet("detalle/{id:int}")]
        public IActionResult Detalle(int id)
        {
            var desarrollador = _desarrolladorService.ObtenerDetalle(id);

            if (desarrollador == null)
                return NotFound();

            return View(desarrollador);
        }

        [HttpGet("crear")]
        public IActionResult Crear()
        {
            return View(new Desarrollador());
        }

        [HttpPost("crear")]
        public IActionResult Crear(Desarrollador desarrollador)
        {
            if (!ModelState.IsValid)
                return View(desarrollador);

            _desarrolladorService.CrearDesarrollador(desarrollador);

            return RedirectToAction("Index");
        }

        [HttpGet("editar/{id:int}")]
        public IActionResult Editar(int id)
        {
            var desarrollador = _desarrolladorService.ObtenerDetalle(id);

            if (desarrollador == null)
                return NotFound();

            return View(desarrollador);
        }

        [HttpPost("editar/{id:int}")]
        public IActionResult Editar(int id, Desarrollador desarrollador)
        {
            if (id != desarrollador.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(desarrollador);

            _desarrolladorService.ActualizarDesarrollador(desarrollador);

            return RedirectToAction("Index");
        }

        [HttpPost("eliminar/{id:int}")]
        public IActionResult Eliminar(int id)
        {
            _desarrolladorService.EliminarDesarrollador(id);
            return RedirectToAction("Index");
        }
    }
}