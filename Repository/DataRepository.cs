using Repository.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DataRepository<T> : DataRepositoryBase<T>, IDataRepository<T> where T : class
    {
        public DataRepository(EventoDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<T>> GetEntitiesAsync()
        {
            return await GetAllAsync();
        }

        public async Task<T> GetEntityAsync(object id)
        {
            return await GetByIdAsync(id);
        }

        public virtual async Task SaveEntityAsync(T entity)
        {
            await AddAsync(entity);
            await SaveChangesAsync();
        }

        public async Task UpdateEntityAsync(object entityId, T entity)
        {
            var existingEntity = await GetEntityAsync(entityId);
            if (existingEntity is not null)
            {
                //_context.Entry(existingEntity).CurrentValues.SetValues(entity);
                var entityType = typeof(T);
                foreach (var property in entityType.GetProperties())
                {
                    var newValue = property.GetValue(entity);
                    if (newValue is not null && !(newValue is string str && string.IsNullOrEmpty(str)))
                    {
                        property.SetValue(existingEntity, newValue);
                    }
                }
                await SaveChangesAsync();
            }
        }

        public async Task DeleteEntityAsync(object entityId)
        {
            T entity = await GetEntityAsync(entityId);
            await DeleteAsync(entity);
            await SaveChangesAsync();
        }
    }
}
