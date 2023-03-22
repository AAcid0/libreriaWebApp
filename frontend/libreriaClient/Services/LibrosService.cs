using libreriaClient.Helpers;
using libreriaClient.Models.Autores;
using libreriaClient.Models.Libros;
using libreriaClient.Services.Interfaces;

namespace libreriaClient.Services
{
    public class LibrosService : ILibrosService
    {
        private readonly HttpClient _client;
        public const string BasePath = "/api/libros";

        public LibrosService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Libro>> GetAllLibros()
        {
            var response = await _client.GetAsync(BasePath);

            return await response.ReadContentAsync<List<Libro>>();
        }

        public async Task<IEnumerable<Libro>> GetLibrosByKeyword(string name)
        {
            var response = await _client.GetAsync(BasePath + $"/by-keyword/{name}");
            response.EnsureSuccessStatusCode();

            return await response.ReadContentAsync<List<Libro>>();
        }

        public async Task<Libro> GetLibroById(long id)
        {
            var response = await _client.GetAsync(BasePath + $"/by-id/{id}");
            response.EnsureSuccessStatusCode();

            return await response.ReadContentAsync<Libro>();
        }

        public async Task<bool> CreateLibro(Libro libro) {
            var response = await _client.PostAsJsonAsync(BasePath, libro);

            if (response.IsSuccessStatusCode)
                return true;
            return false;
        }

        public async Task<bool> UpdateLibro(Libro libro)
        {
            var response = await _client.PutAsJsonAsync(BasePath + $"/update/{libro.Id}", libro);

            if (response.IsSuccessStatusCode)
                return true;
            return false;
        }

        public async Task<bool> DeleteLibro(long libroId)
        {
            var response = await _client.DeleteAsync(BasePath + $"/delete/{libroId}");

            if (response.IsSuccessStatusCode)
                return true;
            return false;
        }

        public async Task<IEnumerable<Autor>> GetAllAutores()
        {
            var response = await _client.GetAsync("/api/autores");

            response.EnsureSuccessStatusCode();

            return await response.ReadContentAsync<List<Autor>>();
        }

        public async Task<IEnumerable<Libro>> GetLibrosByAuthorId(long authorId)
        {
            var response = await _client.GetAsync(BasePath + $"/by-autor/{authorId}");
            response.EnsureSuccessStatusCode();

            return await response.ReadContentAsync<List<Libro>>();
        }
    }
}
