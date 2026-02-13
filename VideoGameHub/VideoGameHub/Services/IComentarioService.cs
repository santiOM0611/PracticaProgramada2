using VideoGameHub.Models;

namespace VideoGameHub.Services
{
    public interface IComentarioService
    {
        void CrearComentario(int videojuegoId, string texto, int valoracion);
        List<Comentario> ObtenerPorVideojuego(int videojuegoId);
        ComentarioViewModel ObtenerComentarioViewModel(int videojuegoId);
    }
}