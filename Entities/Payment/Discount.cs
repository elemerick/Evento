using Entities.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Payment
{
    public class Discount
    {
        public int DiscountId { get; set; }  // Primary Key

        public int EventId { get; set; }  // Foreign Key to Event
        public Event Event { get; set; }  // Navigation Property

        public string DiscountCode { get; set; }

        public decimal DiscountAmount { get; set; }

        public DateTime ExpiryDate { get; set; }

        public DateTime CreatedAt { get; set; }
    }

}
