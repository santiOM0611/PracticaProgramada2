using VideoGameHub.Models;

namespace VideoGameHub.Services
{
    public interface IDesarrolladorService
    {
        List<Desarrollador> ObtenerTodos();
        Desarrollador? ObtenerDetalle(int id);
        bool CrearDesarrollador(Desarrollador desarrollador);
        bool ActualizarDesarrollador(Desarrollador desarrollador);
        bool EliminarDesarrollador(int id);
    }
}