using VideoGameHub.Models;
using VideoGameHub.Repositories;

namespace VideoGameHub.Services
{
    public class ComentarioService : IComentarioService
    {
        private readonly IComentarioRepository _comentarioRepo;
        private readonly IVideojuegoRepository _videojuegoRepo;

        public ComentarioService(
            IComentarioRepository comentarioRepo,
            IVideojuegoRepository videojuegoRepo)
        {
            _comentarioRepo = comentarioRepo;
            _videojuegoRepo = videojuegoRepo;
        }

        public void CrearComentario(int videojuegoId, string texto, int valoracion)
        {
            var comentario = new Comentario
            {
                VideojuegoId = videojuegoId,
                TextoComentario = texto,
                Valoracion = valoracion,
                Fecha = DateTime.Now
            };

            _comentarioRepo.CrearComentario(comentario);
        }

        public List<Comentario> ObtenerPorVideojuego(int videojuegoId)
            => _comentarioRepo.ObtenerPorVideojuego(videojuegoId);

        public ComentarioViewModel ObtenerComentarioViewModel(int videojuegoId)
        {
            var videojuego = _videojuegoRepo.ObtenerPorId(videojuegoId);

            return new ComentarioViewModel
            {
                VideojuegoId = videojuegoId,
                Videojuego = videojuego
            };
        }
    }
}