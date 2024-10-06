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
    internal class BookingsConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            
            builder.Property(p => p.EventId).IsRequired();
            builder.Property(p => p.UserId).IsRequired();
            builder.Property(p => p.NumberOfTickets).IsRequired();
            builder.Property(p => p.BookingDate).IsRequired();
            builder.Property(p => p.TotalPrice).IsRequired().HasColumnType("decimal(10,3)");

            builder.HasOne(b => b.Event)
                .WithMany(e => e.Bookings)
                .HasForeignKey(b => b.EventId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Payment)
                .WithOne(u => u.Booking)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(u => u.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
            builder.Property(u => u.UpdatedAt).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("GETDATE()");
        }
    }
}
