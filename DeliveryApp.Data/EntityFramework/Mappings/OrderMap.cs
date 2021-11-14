using DeliveryApp.Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeliveryApp.Data.EntityFramework.Mappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.OrderDate).IsRequired();
            builder.Property(p => p.IsDelivered).IsRequired();
            builder.HasOne<User>(p => p.User).WithMany(p => p.Orders).HasForeignKey(P => P.UserId);
        }
    }
}
