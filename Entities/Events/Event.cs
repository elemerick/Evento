using Entities.Payment;
using Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Events
{
    public class Event
    {
        public int Id { get; set; }
        public int OrganizerId { get; set; }
        public User Organizer { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int VenueId { get; set; }
        public Venue Venue { get; set; }
        public int TotalSeats { get; set; }
        public decimal PricePerTicket { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation Properties
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Discount> Discounts { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<EventCategoryRelationship> EventCategories { get; set; }
    }

}
