using libreriaClient.Helpers;
using libreriaClient.Models;
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

        public async Task<IEnumerable<LibrosModel>> GetAllLibros()
        {
            var response = await _client.GetAsync(BasePath);

            return await response.ReadContentAsync<List<LibrosModel>>();
        }

        public async Task<IEnumerable<LibrosModel>> GetLibrosByKeyboard(string name)
        {
            var response = await _client.GetAsync(BasePath + $"/by-keyword/{name}");
            response.EnsureSuccessStatusCode();

            return await response.ReadContentAsync<List<LibrosModel>>();
        }
    }
}
