using libreriaClient.Models;

namespace libreriaClient.Services.Interfaces
{
    public interface ILibrosService
    {
        Task<IEnumerable<LibrosModel>> GetAllLibros();
        Task<IEnumerable<LibrosModel>> GetLibrosByKeyboard(string name);
    }
}
