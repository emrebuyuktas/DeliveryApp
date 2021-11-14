using DeliveryApp.Core.Entities.Abstaract;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace DeliveryApp.Core.Entities.Concrete
{
    public class User:IdentityUser<int>,IEntity
    {
        public ICollection<Adress> Adresses { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
