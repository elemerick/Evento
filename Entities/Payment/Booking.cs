using Entities.Events;
using Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Payment
{
    public class Booking
    {
        public int BookingId { get; set; }  // Primary Key

        public int EventId { get; set; }  // Foreign Key to Event
        public Event Event { get; set; }  // Navigation Property

        public int UserId { get; set; }  // Foreign Key to User
        public User User { get; set; }  // Navigation Property

        public DateTime BookingDate { get; set; }

        public int NumberOfTickets { get; set; }

        public decimal TotalPrice { get; set; }

        public string BookingStatus { get; set; }  // "confirmed", "pending", "cancelled"

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        // Navigation Property
        public Payment Payment { get; set; }
    }

}
