using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Payment
{
    public class Payment
    {
        public int PaymentId { get; set; }  // Primary Key

        public int BookingId { get; set; }  // Foreign Key to Booking
        public Booking Booking { get; set; }  // Navigation Property

        public DateTime PaymentDate { get; set; }

        public string PaymentMethod { get; set; }  // "credit_card", "debit_card", "paypal", etc.

        public decimal Amount { get; set; }

        public string PaymentStatus { get; set; }  // "successful", "failed", "pending"

        public DateTime CreatedAt { get; set; }
    }

}
