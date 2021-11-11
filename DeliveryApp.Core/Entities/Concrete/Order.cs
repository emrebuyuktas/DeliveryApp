using DeliveryApp.Core.Entities.Abstaract;
using System;
using System.Collections.Generic;

namespace DeliveryApp.Core.Entities.Concrete
{
    public class Order:IEntity
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsDelivered { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
