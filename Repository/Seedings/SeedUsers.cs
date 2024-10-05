using Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Seedings
{
    internal static class SeedUsers
    {
        internal static void Run(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(new List<User>() { 
                new User () { Id = 1, RoleId = 1, Username = "emerick", FirstName = "Super", LastName = "Admin", Email = "el.emerick@gmail.com", PhoneNumber = "+37061224853", Password = "Admin@123" }
            });
        }
    }
}
