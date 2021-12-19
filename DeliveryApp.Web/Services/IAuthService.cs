using DeliveryApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Services
{
    public interface IAuthService
    {
        Task<Auth> GetAsync(string url);
        Task<string> AddAsync(Auth auth, string url);
        Task DeleteAsync(string url, string id);
        Task UpdateAsync(Auth auth, string url);

    }
}
