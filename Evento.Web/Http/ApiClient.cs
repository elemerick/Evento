namespace Evento.Web.Http
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public class ApiClient<T> : IApiClient<T> where T : class
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: Retrieve an item by ID
        public async Task<T> GetAsync(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string jsonData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(jsonData);
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}, Message: {await response.Content.ReadAsStringAsync()}");
            }
        }

        // GET: Retrieve a list of items
        public async Task<List<T>> GetListAsync(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string jsonData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<T>>(jsonData);
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}, Message: {await response.Content.ReadAsStringAsync()}");
            }
        }

        // POST: Create a new item (with a different model, e.g. MyModelCreate)
        public async Task<HttpResponseMessage> PostAsync<U>(string url, U item) where U : class
        {
            string jsonData = JsonConvert.SerializeObject(item);
            HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(url, content);
            return response;  // Check response.IsSuccessStatusCode in the calling code
        }

        // PUT: Update an existing item (with a different model, e.g. MyModelUpdate)
        public async Task<HttpResponseMessage> PutAsync<V>(string url, V item) where V : class
        {
            string jsonData = JsonConvert.SerializeObject(item);
            HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync(url, content);
            return response;
        }

        // DELETE: Delete an item by ID
        public async Task<HttpResponseMessage> DeleteAsync(string url)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync(url);
            return response;
        }
    }


}
