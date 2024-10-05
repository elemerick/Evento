using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Events
{
    public class EventCategoryRelationship
    {
        public int EventId { get; set; }  // Foreign Key to Event
        public Event Event { get; set; }  // Navigation Property

        public int CategoryId { get; set; }  // Foreign Key to EventCategory
        public EventCategory Category { get; set; }  // Navigation Property
    }

}
