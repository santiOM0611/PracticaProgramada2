using System.ComponentModel.DataAnnotations;

namespace VideoGameHub.Models
{
    public class ComentarioViewModel
    {
        [Required]
        public int VideojuegoId { get; set; }

        [Required(ErrorMessage = "El comentario es obligatorio")]
        public string TextoComentario { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "La valoración debe estar entre 1 y 5")]
        public int Valoracion { get; set; }

        public Videojuego? Videojuego { get; set; }
    }
}