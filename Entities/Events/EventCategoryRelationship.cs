using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Events
{
    public class EventCategoryRelationship
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }

        public int CategoryId { get; set; }
        public EventCategory Category { get; set; }
    }

}
