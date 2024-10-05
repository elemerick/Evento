using Entities.Events;
using Entities.Payment;

namespace Entities.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public required int RoleId { get; set; }
        public Role Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation Properties
        public ICollection<Booking> Bookings { get; set; }  // Relationship: User can have many bookings
        public ICollection<Event> OrganizedEvents { get; set; }  // Relationship: User can organize many events
    }

}
