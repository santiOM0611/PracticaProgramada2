using VideoGameHub.Data;
using VideoGameHub.Models;
using Microsoft.EntityFrameworkCore;

namespace VideoGameHub.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly AppDbContext _context;

        public ComentarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CrearComentario(Comentario comentario)
        {
            _context.Comentarios.Add(comentario);
            _context.SaveChanges();
        }

        public List<Comentario> ObtenerTodos()
        {
            return _context.Comentarios
                .Include(c => c.Videojuego)
                .OrderByDescending(c => c.Fecha)
                .ToList();
        }

        public List<Comentario> ObtenerPorVideojuego(int videojuegoId)
            => _context.Comentarios
                .Include(c => c.Videojuego)
                .Where(c => c.VideojuegoId == videojuegoId)
                .OrderByDescending(c => c.Fecha)
                .ToList();
    }
}