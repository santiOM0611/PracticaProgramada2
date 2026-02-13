using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoGameHub.Models
{
    public class Comentario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El comentario es obligatorio")]
        public string TextoComentario { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "La valoración debe estar entre 1 y 5")]
        public int Valoracion { get; set; }

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now;

        // FK hacia Videojuego
        [ForeignKey(nameof(Videojuego))]
        public int VideojuegoId { get; set; }
        public Videojuego? Videojuego { get; set; }
    }
}