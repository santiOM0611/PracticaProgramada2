using VideoGameHub.Models;
using VideoGameHub.Repositories;

namespace VideoGameHub.Services
{
    public class VideojuegoService : IVideojuegoService
    {
        private readonly IVideojuegoRepository _repository;
        private readonly IFileService _fileService;

        public VideojuegoService(IVideojuegoRepository repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        public List<Videojuego> ObtenerTodos()
            => _repository.ObtenerTodos();

        public Videojuego? ObtenerDetalle(int id)
            => _repository.ObtenerPorId(id);

        public bool CrearVideojuego(Videojuego videojuego)
        {
            _repository.Agregar(videojuego);
            return true;
        }

        public bool ActualizarVideojuego(Videojuego videojuego)
        {
            if (!_repository.ExisteId(videojuego.Id))
                return false;

            _repository.Actualizar(videojuego);
            return true;
        }

        public bool EliminarVideojuego(int id)
        {
            if (!_repository.ExisteId(id))
                return false;

            _repository.Eliminar(id);
            return true;
        }

        public string GuardarImagen(IFormFile? imagen)
        {
            return _fileService.GuardarImagen(imagen);
        }
    }
}