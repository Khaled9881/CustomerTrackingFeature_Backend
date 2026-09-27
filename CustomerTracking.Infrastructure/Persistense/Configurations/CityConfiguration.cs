using CustomerTracking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerTracking.Infrastructure.Persistense.Configurations
{
    // CityConfiguration.cs
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Cities");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Same city name can repeat under different governorates,
            // but not twice under the same one.
            builder.HasIndex(c => new { c.GovernorateId, c.Name })
                .IsUnique();

            builder.HasMany(c => c.Customers)
                .WithOne(cust => cust.City)
                .HasForeignKey(cust => cust.CityId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
