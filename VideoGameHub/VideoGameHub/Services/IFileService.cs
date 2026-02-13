namespace VideoGameHub.Services
{
    public interface IFileService
    {
        string? GuardarImagen(IFormFile? archivo);
    }
}