using Entities.Users;
using Microsoft.EntityFrameworkCore;
using Repository.DataContext;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DataAccessLogic
{
    public class UsersRepository : DataRepository<User>, IUsersRepository
    {
        private readonly EventoDBContext _context;
        public UsersRepository(EventoDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User?> GetUserAsync(int id)
        {
            return await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<User>> GetUsersAsync()
        {
            return await _context.Users
                .Include(u => u.Role)
                .ToListAsync();
        }

        public async Task UpdateUserAsync(int id, User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            User? oldUser = await _context.Users.FindAsync(id);
            if (oldUser == null)
            {
                throw new ArgumentException(nameof(id));
            }
            oldUser.FirstName = user.FirstName;
            oldUser.LastName = user.LastName;
            oldUser.PhoneNumber = user.PhoneNumber;
            oldUser.Email = user.Email;
            _context.Users.Update(oldUser);
            await _context.SaveChangesAsync();
        }
    }
}
