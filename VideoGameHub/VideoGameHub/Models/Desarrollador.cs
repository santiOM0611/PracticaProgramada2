using System.ComponentModel.DataAnnotations;

namespace VideoGameHub.Models
{
    public class Desarrollador
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El país es obligatorio")]
        public string Pais { get; set; }

        public string? SitioWeb { get; set; }

        [Range(1950, 2100, ErrorMessage = "Año de fundación inválido")]
        public int AnoFundacion { get; set; }

        public List<Videojuego> Videojuegos { get; set; } = new();
    }
}