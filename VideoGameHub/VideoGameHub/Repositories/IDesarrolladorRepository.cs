using VideoGameHub.Models;

namespace VideoGameHub.Repositories
{
    public interface IDesarrolladorRepository
    {
        List<Desarrollador> ObtenerTodos();
        Desarrollador? ObtenerPorId(int id);
        bool ExisteId(int id);
        void Agregar(Desarrollador desarrollador);
        void Actualizar(Desarrollador desarrollador);
        void Eliminar(int id);
    }
}