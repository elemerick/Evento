﻿using Entities.Payment;
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
    internal class DiscountsConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).ValueGeneratedOnAdd();

            builder.Property(r => r.DiscountCode).HasMaxLength(5);
            builder.HasAlternateKey(r => r.DiscountCode);

            builder.Property(r => r.EventId).IsRequired();
            builder.Property(r => r.DiscountAmount).IsRequired().HasColumnType("decimal(10,3)");

            builder.HasOne(d => d.Event)
                .WithMany(e => e.Discounts)
                .HasForeignKey(e => e.EventId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(u => u.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
        }
    }
}
