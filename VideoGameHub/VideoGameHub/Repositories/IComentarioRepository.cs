using VideoGameHub.Models;

namespace VideoGameHub.Repositories
{
    public interface IComentarioRepository
    {
        void CrearComentario(Comentario comentario);
        List<Comentario> ObtenerTodos();
        List<Comentario> ObtenerPorVideojuego(int videojuegoId);
    }
}