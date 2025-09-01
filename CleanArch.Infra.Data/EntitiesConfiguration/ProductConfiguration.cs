using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // properties requirement and id
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(120).IsRequired();
            builder.Property(p => p.Description).IsRequired().HasMaxLength(120);
            builder.Property(p => p.Price).IsRequired().HasPrecision(10, 2);

            // relation - one Category to many Products
            builder.HasOne(e => e.Category).WithMany(e => e.Products)
                .HasForeignKey(e => e.CategoryId);
        }
    }
}
