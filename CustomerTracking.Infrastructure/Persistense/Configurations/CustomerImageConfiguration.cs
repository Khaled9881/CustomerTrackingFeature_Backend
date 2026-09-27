using CustomerTracking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerTracking.Infrastructure.Persistense.Configurations
{
    // CustomerImageConfiguration.cs
    public class CustomerImageConfiguration : IEntityTypeConfiguration<CustomerImage>
    {
        public void Configure(EntityTypeBuilder<CustomerImage> builder)
        {
            builder.ToTable("CustomerImages");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.ImagePath)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(i => i.IsMain)
                .IsRequired()
                .HasDefaultValue(false);
        }
    }
}
