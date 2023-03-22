using libreriaClient.Models.Autores;

namespace libreriaClient.Services.Interfaces
{
    public interface IAutoresService
    {
        Task<IEnumerable<Autor>> GetAllAutores();
        Task<Autor> GetAutorById(long id);
        Task<IEnumerable<Autor>> GetAutoresByKeyword(string keyword);
        Task<bool> CreateAutor(Autor autor);
        Task<bool> UpdateAutor(Autor autor);
        Task<bool> DeleteAutor(long id);
        Task<bool> DeleteLibrosByAutor(long Authorid);
    }
}
