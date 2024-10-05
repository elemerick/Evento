using Entities.Events;
using Entities.Payment;
using Entities.Users;
using Microsoft.EntityFrameworkCore;
using Repository.Configurations;

namespace Repository.DataContext
{
    internal class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<EventCategoryRelationship> EventCategoriesRelationship { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Venue> Venue { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=EventsDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new RolesConfiguration().Configure(modelBuilder.Entity<Role>());
            new UsersConfiguration().Configure(modelBuilder.Entity<User>());
        }

    }
}
