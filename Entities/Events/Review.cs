using Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Events
{
    public class Review
    {
        public int ReviewId { get; set; }  // Primary Key

        public int EventId { get; set; }  // Foreign Key to Event
        public Event Event { get; set; }  // Navigation Property

        public int UserId { get; set; }  // Foreign Key to User
        public User User { get; set; }  // Navigation Property

        public int Rating { get; set; }  // Rating from 1 to 5

        public string ReviewText { get; set; }

        public DateTime CreatedAt { get; set; }
    }

}
