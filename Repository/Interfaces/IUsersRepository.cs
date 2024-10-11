using Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IUsersRepository : IDataRepository<User>
    {
        Task<ICollection<User>> GetUsersAsync();
        Task<User?> GetUserAsync(int id);
        Task UpdateUserAsync(int id, User user);
    }
}
