using DeliveryApp.Core.Dtos;

namespace DeliveryApp.Web.Models
{
    public class UserProfile
    {
        public UserDto Data { get; set; }
        public AddressDto Address { get; set; }
    }
}
