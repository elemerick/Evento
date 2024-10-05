using Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Seedings
{
    internal static class SeedRoles
    {
        internal static void Run(ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(new List<Role>()
            {
                new Role() { Id = 1, Name = "Customer", Description = "Customer" },
                new Role() { Id = 2, Name = "Organizer", Description = "Organizer" },
                new Role() { Id = 3, Name = "Administrator", Description = "Administrator" }
            });
        }
    }
}
