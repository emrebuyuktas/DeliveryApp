using DeliveryApp.Core.Dtos;
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
        Task<string> RegisterAsync(UserRegisterDto userRegisterDto, string url);
        Task DeleteAsync(string url, string id);
        Task UpdateAsync(Auth auth, string url);
        Task<string> LoginAsync(UserLoginDto userLoginDto,string url);

    }
}
