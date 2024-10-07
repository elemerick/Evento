using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IDataRepository<T> where T : class
    {
        Task<T> GetEntityAsync(object id);
        Task<IEnumerable<T>> GetEntitiesAsync();
        Task SaveEntityAsync(T entity);
        Task UpdateEntityAsync(object entityId, T entity);
        Task DeleteEntityAsync(object entityId);
    }
}
