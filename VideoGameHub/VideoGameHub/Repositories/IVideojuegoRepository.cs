using VideoGameHub.Models;

namespace VideoGameHub.Repositories
{
    public interface IVideojuegoRepository
    {
        List<Videojuego> ObtenerTodos();
        Videojuego? ObtenerPorId(int id);
        bool ExisteId(int id);
        void Agregar(Videojuego videojuego);
        void Actualizar(Videojuego videojuego);
        void Eliminar(int id);
    }
}