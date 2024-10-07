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
    }
}
