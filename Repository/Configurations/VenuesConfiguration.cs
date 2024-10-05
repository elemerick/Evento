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
    internal class VenuesConfiguration : IEntityTypeConfiguration<Venue>
    {
        public void Configure(EntityTypeBuilder<Venue> builder)
        {
            builder.HasKey(v => v.Id);
            builder.Property(v => v.Id).ValueGeneratedOnAdd();

            builder.Property(v => v.Name).IsRequired();
            builder.Property(v => v.City).IsRequired();
            builder.Property(v => v.Address).IsRequired();
            builder.Property(v => v.State).IsRequired();
            builder.Property(v => v.Capacity).IsRequired();
        }
    }
}
