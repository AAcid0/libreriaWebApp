using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace libreriaClient.Helpers
{
    public static class HttpClientExtensions
    {
        public static async Task<T> ReadContentAsync<T>(this HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode == false)
                throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");

            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true

            };

            
            var result = JsonSerializer.Deserialize<T>(
                dataAsString, jsonOptions);

            return result;
        }
    }
}
