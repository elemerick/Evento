using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IDomainBase<T> where T : class
    {
        Task<T> GetEntityAsync(int id);
        Task<IEnumerable<T>> GetEntitiesAsync();
        Task SaveEntityAsync(T entity);
        Task UpdateEntityAsync(T entity);
        Task DeleteEntityAsync(T entity);
    }
}
