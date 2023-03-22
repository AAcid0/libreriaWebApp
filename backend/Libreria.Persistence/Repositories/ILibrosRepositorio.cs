using Libreria.Domain;

namespace Libreria.Persistence.Repositories
{
    public interface ILibrosRepositorio
    {
        Task<IEnumerable<Libro>> GetAllLibros();
        Task<IEnumerable<Libro>> GetLibroByName(string name);
        Task<bool> CreateLibro(Libro libro);
        Task<bool> DeleteLibro(Libro libro);
    }
}
