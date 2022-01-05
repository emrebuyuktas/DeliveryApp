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
        Task<User> GetAsync(string url,string token);
        Task<User> RegisterAsync(UserRegisterDto userRegisterDto, string url);
        Task DeleteAsync(string url, string id);
        Task UpdateAsync(UserUpdateDto userUpdateDto, string url);
        Task<User> LoginAsync(UserLoginDto userLoginDto,string url);
        Task<User> GetCurrentUserAsync(string url, string token);

    }
}
