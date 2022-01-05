using DeliveryApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Services
{
    public interface IAddressService
    {
        Task<Address> GetAllAsync(string url);
        Task<UserAddress> GetUserAddressAsync(string url);
        Task<string> AddAsync(ProductList product, string url);
    }
}
