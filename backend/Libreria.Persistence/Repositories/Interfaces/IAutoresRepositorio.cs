using Libreria.Domain;

namespace Libreria.Persistence.Repositories.Interfaces
{
    public interface IAutoresRepositorio
    {
        Task<IEnumerable<Autor>> GetAllAutores();
        Task<Autor> GetAutorByName(string name);
        Task<bool> CreateAutor(Autor autor);
        Task<bool> DeleteAutor(Autor autor);
    }
}
