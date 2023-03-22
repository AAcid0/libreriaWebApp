using Libreria.Domain;

namespace Libreria.Persistence.Repositories.Interfaces
{
    public interface IAutoresRepositorio
    {
        Task<IEnumerable<Autor>> GetAllAutores();
        Task<IEnumerable<Autor>> GetAutorByKeyword(string name);
        Task<Autor> GetAutorById(long id);
        Task<bool> CreateAutor(Autor autor);
        Task<bool> DeleteAutor(long id);
        Task<bool> UpdateAutor(Autor autor);
    }
}
