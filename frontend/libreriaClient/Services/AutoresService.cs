using libreriaClient.Helpers;
using libreriaClient.Models.Autores;
using libreriaClient.Services.Interfaces;
using System.Net.Http.Json;

namespace libreriaClient.Services
{
    public class AutoresService : IAutoresService
    {
        private readonly HttpClient _client;
        public const string BasePath = "/api/autores";

        public AutoresService(HttpClient client)
        {
            _client = client;
        }

        public async Task<bool> UpdateAutor(Autor autor)
        {
            var response = await _client.PutAsJsonAsync(BasePath + $"/update/{autor.Id}",autor);

            if (response.IsSuccessStatusCode)
                return true;
            return false;
        }

        public async Task<bool> CreateAutor(Autor autor)
        {
            var response = await _client.PostAsJsonAsync(BasePath,autor);
            
            if(response.IsSuccessStatusCode)
                return true;
            return false;
        }

        public Task<IEnumerable<Autor>> GetAllAutores()
        {
            throw new NotImplementedException();
        }

        public async Task<Autor> GetAutorById(long id)
        {
            if(id != 0)
            {
                var response = await _client.GetAsync(BasePath + $"/by-id/{id}");
                response.EnsureSuccessStatusCode();
                return await response.ReadContentAsync<Autor>();
            }

            return new Autor();
        }

        public async Task<IEnumerable<Autor>> GetAutoresByKeyword(string keyword)
        {
            var response = await _client.GetAsync(BasePath + $"/by-keyword/{keyword}");
            response.EnsureSuccessStatusCode();

            return await response.ReadContentAsync<List<Autor>>();
        }

        public async Task<bool> DeleteAutor(long id)
        {
            var response = await _client.DeleteAsync(BasePath + $"/delete/{id}");

            if (response.IsSuccessStatusCode)
                return true;
            return false;
        }
    }
}
