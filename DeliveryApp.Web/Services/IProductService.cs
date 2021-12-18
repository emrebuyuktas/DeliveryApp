
using DeliveryApp.Web.HttpService;
using DeliveryApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Services
{
    public interface IProductService
    {
        Task<Product> GetAsync(string url);
    }
}
