using VideoGameHub.Models;
using Microsoft.EntityFrameworkCore;

namespace VideoGameHub.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Videojuego> Videojuegos { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Desarrollador> Desarrolladores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Desarrollador <-> Videojuego (1 a muchos)
            modelBuilder.Entity<Videojuego>()
                .HasOne(v => v.Desarrollador)
                .WithMany(d => d.Videojuegos)
                .HasForeignKey(v => v.DesarrolladorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Videojuego <-> Comentario (1 a muchos)
            modelBuilder.Entity<Comentario>()
                .HasOne(c => c.Videojuego)
                .WithMany(v => v.Comentarios)
                .HasForeignKey(c => c.VideojuegoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}