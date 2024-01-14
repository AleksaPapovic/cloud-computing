using Newtonsoft.Json;
using System.Text.Json;

namespace BibliotekaEkspozitura.Utils
{
    public static class HttpUtils
    {
        private static JsonSerializerOptions SerializerOptions { get; set; } = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public static StringContent HttpClientRequest<T>(T request) where T : class
        {
            string json = JsonConvert.SerializeObject(request);

            return new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        }

        public static async Task<S> HttpClientResponse<S>(HttpResponseMessage? response) where S : new()
        {
            string? result = null;
            if (response != null)
            {
                result = await response.Content?.ReadAsStringAsync();
                return System.Text.Json.JsonSerializer.Deserialize<S>(result.ToString() ?? "", SerializerOptions) ?? new S();
            }
            return new S();
        }
        public static async Task<string> HttpClientResponse(HttpResponseMessage? response)
        {
            if (response != null)
            {
                return await response.Content?.ReadAsStringAsync();
            }
            return "";
        }
    }
}
