using Entities.Payment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configurations
{
    internal class PaymentsConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.PaymentId).ValueGeneratedOnAdd();
            builder.Property(p => p.PaymentMethodId).IsRequired();
            builder.Property(p => p.BookingId).IsRequired();
            builder.Property(p => p.Amount).IsRequired().HasColumnType("decimal(10,3)");
            builder.Property(p => p.PaymentStatus)
                .IsRequired()
                .HasDefaultValue(PaymentStatus.Pending)
                .HasSentinel(PaymentStatus.Pending);

            builder.HasOne(e => e.PaymentMethod)
                .WithMany(pm => pm.Payments)
                .HasForeignKey(e => e.PaymentMethodId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Booking)
                .WithOne(b => b.Payment)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(u => u.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
            builder.Property(u => u.UpdatedAt).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("GETDATE()");

        }
    }
}
