using DeliveryApp.Core.Entities.Abstaract;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace DeliveryApp.Core.Entities.Concrete
{
    public class User:IdentityUser<int>,IEntity
    {
        public ICollection<Adress> Adresses { get; set; }
        public string UserSurname { get; set; }

    }
}
