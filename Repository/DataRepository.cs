using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DataRepository<T> : IDataRepository<T> where T : class
    {
        private readonly IDataRepositoryBase<T> _repo;

        public DataRepository(IDataRepositoryBase<T> repo)
        {
            _repo = repo;
        }

        public virtual async Task SaveEntityAsync(T entity)
        {
            await _repo.AddAsync(entity);
            await _repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetEntitiesAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<T> GetEntityAsync(object id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _repo.SaveChangesAsync();
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
                await _repo.SaveChangesAsync();
            }
        }
        public async Task DeleteEntityAsync(object entityId)
        {
            T entity = await GetEntityAsync(entityId);
            await _repo.DeleteAsync(entity);
            await _repo.SaveChangesAsync();
        }

    }
}
