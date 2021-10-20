using DeliveryApp.Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DeliveryApp.Data.EntityFramework.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Name).HasMaxLength(100);
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.Description).HasMaxLength(500);
            builder.Property(a => a.Description).IsRequired();
            builder.Property(a => a.PictureUrl).HasMaxLength(250);
            builder.Property(a => a.PictureUrl).IsRequired();
            builder.HasOne(b => b.ProductBrand).WithMany().HasForeignKey(p => p.ProductBrandId);
            builder.HasOne(t => t.ProductType).WithMany().HasForeignKey(p => p.ProductTypeId);

        }
    }
}
