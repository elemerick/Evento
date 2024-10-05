using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Events
{
    public class EventCategory
    {
        public int CategoryId { get; set; }  // Primary Key

        public string CategoryName { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        // Navigation Property
        public ICollection<EventCategoryRelationship> EventCategories { get; set; }
    }

}
