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
        public int Id { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public required string DiscountCode { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
