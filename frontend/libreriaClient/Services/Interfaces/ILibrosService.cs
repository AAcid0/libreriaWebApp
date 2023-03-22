using libreriaClient.Models.Autores;
using libreriaClient.Models.Libros;

namespace libreriaClient.Services.Interfaces
{
    public interface ILibrosService
    {
        Task<IEnumerable<Libro>> GetAllLibros();
        Task<IEnumerable<Libro>> GetLibrosByKeyword(string name);
        Task<Libro> GetLibroById(long libroId);
        Task<bool> CreateLibro(Libro libro);
        Task<bool> UpdateLibro(Libro libro);
        Task<bool> DeleteLibro(long libroId);
        Task<IEnumerable<Autor>> GetAllAutores();
        Task<IEnumerable<Libro>> GetLibrosByAuthorId(long authorId);
    }
}
