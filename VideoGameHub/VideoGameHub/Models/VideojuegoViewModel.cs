namespace VideoGameHub.Models
{
    public class VideojuegoViewModel
    {
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public string Plataforma { get; set; }
        public decimal Precio { get; set; }
        public int DesarrolladorId { get; set; }

        // Solo para el formulario
        public IFormFile? Imagen { get; set; }
    }
}