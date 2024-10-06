using Entities.Events;
using Entities.Payment;
using Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Configurations;
using Repository.Seedings;

namespace Repository.DataContext
{
    public class EventoDBContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public EventoDBContext(DbContextOptions<EventoDBContext> options,
            IConfiguration configuration)
        : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<EventCategoryRelationship> EventCategoriesRelationship { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Venue> Venue { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new RolesConfiguration().Configure(modelBuilder.Entity<Role>());
            new UsersConfiguration().Configure(modelBuilder.Entity<User>());
            new EventsConfiguration().Configure(modelBuilder.Entity<Event>());
            new EventCategoriesConfiguration().Configure(modelBuilder.Entity<EventCategory>());
            new EventCategoryRelationshipsConfiguration().Configure(modelBuilder.Entity<EventCategoryRelationship>());
            new BookingsConfiguration().Configure(modelBuilder.Entity<Booking>());
            new ReviewsConfiguration().Configure(modelBuilder.Entity<Review>());
            new DiscountsConfiguration().Configure(modelBuilder.Entity<Discount>());
            new PaymentsConfiguration().Configure(modelBuilder.Entity<Payment>());
            new PaymentMethodsConfiguration().Configure(modelBuilder.Entity<PaymentMethod>());
            new VenuesConfiguration().Configure(modelBuilder.Entity<Venue>());

            SeedRoles.Run(modelBuilder);
            SeedUsers.Run(modelBuilder);
        }

    }
}
