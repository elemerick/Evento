
using Repository;

namespace Domain
{
    public class DomainBase<T> : IDomainBase<T> where T : class
    {
        private readonly IDataRepositoryBase<T> _repo;

        public DomainBase(IDataRepositoryBase<T> repo)
        {
            _repo = repo;
        }

        public virtual async Task SaveEntityAsync(T entity)
        {
            await _repo.AddAsync(entity);
            await _repo.SaveChangesAsync();
        }

        public async Task DeleteEntityAsync(T entity)
        {
            await _repo.DeleteAsync(entity);
            await _repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetEntitiesAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<T> GetEntityAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _repo.SaveChangesAsync();
        }

        public async Task UpdateEntityAsync(T entity)
        {
            await _repo.UpdateAsync(entity);
            await _repo.SaveChangesAsync();
        }
    }
}
