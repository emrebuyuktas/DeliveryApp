using DeliveryApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Services
{
    public interface IBasketService
    {
        Task<Basket> GetAsync(string url);
        Task<string> AddAsync(Basket basket, string url);
        Task DeleteAsync(string url, string id);
        Task UpdateAsync(Basket basket, string url);

    }
}
