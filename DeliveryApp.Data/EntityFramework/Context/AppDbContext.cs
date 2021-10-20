using DeliveryApp.Core.Entities.Concrete;
using DeliveryApp.Data.EntityFramework.Mappings;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.Data.EntityFramework.Context
{
    public class AppDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new ProductBrandMap());
            modelBuilder.ApplyConfiguration(new ProductTypeMap());
        }
    }
}
