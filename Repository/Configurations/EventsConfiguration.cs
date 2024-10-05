using Entities.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configurations
{
    internal class EventsConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.OrganizerId).IsRequired();
            builder.Property(e => e.VenueId).IsRequired();
            builder.Property(e => e.TotalSeats).IsRequired();
            builder.Property(e => e.StartTime).IsRequired();
            builder.Property(e => e.PricePerTicket).IsRequired();
            builder.Property(e => e.EventName).IsRequired();
            builder.Property(e => e.EventDescription).IsRequired();
            builder.Property(e => e.EndTime).IsRequired();

            builder.Property(u => u.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
            builder.Property(u => u.UpdatedAt).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("GETDATE()");

            
        }
    }
}
