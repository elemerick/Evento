﻿using Entities.Events;
using Entities.Users;

namespace Entities.Payment
{
    public class Booking
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime BookingDate { get; set; }
        public int NumberOfTickets { get; set; }
        public decimal TotalPrice { get; set; }
        public BookingStatus BookingStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Payment Payment { get; set; }
    }

    public enum BookingStatus { Confirmed, Pending, Cancelled }
}
