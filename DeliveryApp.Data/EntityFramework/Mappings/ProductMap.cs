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
            builder.Property(p => p.Name).HasMaxLength(100);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Price).HasColumnType("DECIMAL");
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(500);
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.PictureUrl).HasMaxLength(250);
            builder.Property(p => p.PictureUrl).IsRequired();
            builder.HasOne(b => b.ProductBrand).WithMany().HasForeignKey(p => p.ProductBrandId);
            builder.HasOne(t => t.ProductType).WithMany().HasForeignKey(p => p.ProductTypeId);

        }
    }
}
