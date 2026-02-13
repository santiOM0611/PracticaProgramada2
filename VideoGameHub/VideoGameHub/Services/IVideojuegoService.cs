using VideoGameHub.Models;

namespace VideoGameHub.Services
{
    public interface IVideojuegoService
    {
        List<Videojuego> ObtenerTodos();
        Videojuego? ObtenerDetalle(int id);
        bool CrearVideojuego(Videojuego videojuego);
        bool ActualizarVideojuego(Videojuego videojuego);
        bool EliminarVideojuego(int id);
        string GuardarImagen(IFormFile? imagen);
    }
}