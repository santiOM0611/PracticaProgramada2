using VideoGameHub.Data;
using VideoGameHub.Models;
using Microsoft.EntityFrameworkCore;

namespace VideoGameHub.Repositories
{
    public class DesarrolladorRepository : IDesarrolladorRepository
    {
        private readonly AppDbContext _context;

        public DesarrolladorRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Desarrollador> ObtenerTodos()
            => _context.Desarrolladores
                .OrderBy(d => d.Nombre)
                .ToList();

        public Desarrollador? ObtenerPorId(int id)
            => _context.Desarrolladores
                .Include(d => d.Videojuegos)
                .FirstOrDefault(d => d.Id == id);

        public bool ExisteId(int id)
            => _context.Desarrolladores.Any(d => d.Id == id);

        public void Agregar(Desarrollador desarrollador)
        {
            _context.Desarrolladores.Add(desarrollador);
            _context.SaveChanges();
        }

        public void Actualizar(Desarrollador desarrollador)
        {
            _context.Desarrolladores.Update(desarrollador);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var desarrollador = ObtenerPorId(id);
            if (desarrollador != null)
            {
                _context.Desarrolladores.Remove(desarrollador);
                _context.SaveChanges();
            }
        }
    }
}