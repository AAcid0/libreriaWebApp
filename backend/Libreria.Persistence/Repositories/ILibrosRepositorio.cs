using Libreria.Domain;

namespace Libreria.Persistence.Repositories
{
    public interface ILibrosRepositorio
    {
        Task<IEnumerable<Libro>> GetAllLibros();
        Task<IEnumerable<Libro>> GetLibroByKeyword(string name);
        Task<bool> CreateLibro(Libro libro);
        Task<bool> DeleteLibro(long id);
        Task<Libro> GetLibroById(long id);
        Task<bool> UpdateLibro(Libro libro);
        Task<IEnumerable<Libro>> GetLibrosByAuthorId(long authorId);
        Task<bool> DeleteLibrosByAuthorId(long authorId);
    }
}
