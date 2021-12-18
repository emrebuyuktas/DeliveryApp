using DeliveryApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Services
{
    public interface IBrandService
    {
        Task<Brand> GetAsync(string url);
    }
}
