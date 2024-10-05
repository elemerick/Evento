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
        public int EventId { get; set; }  // Primary Key

        public int OrganizerId { get; set; }  // Foreign Key to User
        public User Organizer { get; set; }  // Navigation Property

        public string EventName { get; set; }

        public string EventDescription { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int VenueId { get; set; }  // Foreign Key to Venue
        public Venue Venue { get; set; }  // Navigation Property

        public int TotalSeats { get; set; }

        public decimal PricePerTicket { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        // Navigation Properties
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<EventCategoryRelationship> EventCategories { get; set; }
    }

}
