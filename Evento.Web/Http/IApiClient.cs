
namespace Evento.Web.Http
{
    public interface IApiClient<T> where T : class
    {
        Task<HttpResponseMessage> DeleteAsync(string url);
        Task<T> GetAsync(string url);
        Task<List<T>> GetListAsync(string url);
        Task<HttpResponseMessage> PostAsync<U>(string url, U item) where U : class;
        Task<HttpResponseMessage> PutAsync<V>(string url, V item) where V : class;
    }
}