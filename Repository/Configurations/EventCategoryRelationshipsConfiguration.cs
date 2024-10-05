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
    internal class EventCategoryRelationshipsConfiguration : IEntityTypeConfiguration<EventCategoryRelationship>
    {
        public void Configure(EntityTypeBuilder<EventCategoryRelationship> builder)
        {
            builder.HasKey(ecr => ecr.Id);
            builder.Property(ecr => ecr.Id).ValueGeneratedOnAdd();

            builder.HasAlternateKey(ecr => new { ecr.EventId, ecr.CategoryId });
            
            builder.HasOne(ecr => ecr.Event)
                .WithMany(e => e.EventCategories)
                .HasForeignKey(ecr => ecr.EventId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ecr => ecr.Category)
                .WithMany(e => e.EventCategories)
                .HasForeignKey(ecr => ecr.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
