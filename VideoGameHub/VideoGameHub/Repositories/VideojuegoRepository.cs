using VideoGameHub.Data;
using VideoGameHub.Models;
using Microsoft.EntityFrameworkCore;

namespace VideoGameHub.Repositories
{
    public class VideojuegoRepository : IVideojuegoRepository
    {
        private readonly AppDbContext _context;

        public VideojuegoRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Videojuego> ObtenerTodos()
            => _context.Videojuegos
                .Include(v => v.Desarrollador)
                .OrderBy(v => v.Titulo)
                .ToList();

        public Videojuego? ObtenerPorId(int id)
            => _context.Videojuegos
                .Include(v => v.Desarrollador)
                .Include(v => v.Comentarios)
                .FirstOrDefault(v => v.Id == id);

        public bool ExisteId(int id)
            => _context.Videojuegos.Any(v => v.Id == id);

        public void Agregar(Videojuego videojuego)
        {
            _context.Videojuegos.Add(videojuego);
            _context.SaveChanges();
        }

        public void Actualizar(Videojuego videojuego)
        {
            _context.Videojuegos.Update(videojuego);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var videojuego = ObtenerPorId(id);
            if (videojuego != null)
            {
                _context.Videojuegos.Remove(videojuego);
                _context.SaveChanges();
            }
        }
    }
}