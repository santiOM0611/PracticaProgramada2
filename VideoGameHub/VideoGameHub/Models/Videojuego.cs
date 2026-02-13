using System.ComponentModel.DataAnnotations;

namespace VideoGameHub.Models
{
    public class Videojuego
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El género es obligatorio")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "La plataforma es obligatoria")]
        public string Plataforma { get; set; }

        [Required]
        [Range(0.01, 10000, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal Precio { get; set; }

        public string? ImagenUrl { get; set; }

        // FK hacia Desarrollador
        public int DesarrolladorId { get; set; }
        public Desarrollador? Desarrollador { get; set; }

        public List<Comentario> Comentarios { get; set; } = new();
    }
}