using DeliveryApp.Core.Entities.Abstaract;
using Microsoft.AspNetCore.Identity;

namespace DeliveryApp.Core.Entities.Concrete
{
    public class User:IdentityUser<int>,IEntity
    {
        public Adress Adresses { get; set; }
        public string UserSurname { get; set; }

    }
}
