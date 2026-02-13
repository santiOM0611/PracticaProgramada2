using VideoGameHub.Models;
using VideoGameHub.Repositories;

namespace VideoGameHub.Services
{
    public class DesarrolladorService : IDesarrolladorService
    {
        private readonly IDesarrolladorRepository _repository;

        public DesarrolladorService(IDesarrolladorRepository repository)
        {
            _repository = repository;
        }

        public List<Desarrollador> ObtenerTodos()
            => _repository.ObtenerTodos();

        public Desarrollador? ObtenerDetalle(int id)
            => _repository.ObtenerPorId(id);

        public bool CrearDesarrollador(Desarrollador desarrollador)
        {
            _repository.Agregar(desarrollador);
            return true;
        }

        public bool ActualizarDesarrollador(Desarrollador desarrollador)
        {
            if (!_repository.ExisteId(desarrollador.Id))
                return false;

            _repository.Actualizar(desarrollador);
            return true;
        }

        public bool EliminarDesarrollador(int id)
        {
            if (!_repository.ExisteId(id))
                return false;

            _repository.Eliminar(id);
            return true;
        }
    }
}