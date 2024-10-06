using Entities.Events;
using Entities.Payment;
using Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configurations
{
    internal class ReviewsConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).ValueGeneratedOnAdd();

            builder.Property(r => r.ReviewText).HasMaxLength(300);
            builder.Property(r => r.Rating).IsRequired();
            builder.Property(r => r.UserId).IsRequired();
            builder.Property(r => r.EventId).IsRequired();

            builder.HasOne(b => b.Event)
                .WithMany(e => e.Reviews)
                .HasForeignKey(b => b.EventId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(r => r.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");

        }
    }
}
