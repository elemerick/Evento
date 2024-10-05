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
        public int Id { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int Rating { get; set; }

        public string ReviewText { get; set; }

        public DateTime CreatedAt { get; set; }
    }

}
