using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Payment
{
    public class Payment
    {
        public int Id { get; set; }
        public Guid PaymentId { get; set; }

        public int BookingId { get; set; }
        public Booking Booking { get; set; }

        public DateTime PaymentDate { get; set; }

        public int PaymentMethodId { get; set; }  
        public PaymentMethod PaymentMethod { get; set; }
        public decimal Amount { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public enum PaymentStatus { Successful, Failed, Pending }

}
