using DeliveryApp.Core.Dtos;
using DeliveryApp.Web.Models;
using DeliveryApp.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IAddressService _address;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserController(IAuthService authService, IAddressService address, IHttpContextAccessor httpContextAccessor)
        {
            _authService = authService;
            _address = address;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public async Task<IActionResult> UserProfile(int userId)
        {
            var token = _httpContextAccessor.HttpContext.Request
.Cookies["DeliveryApp"];
            var user = await _authService.GetAsync($"https://localhost:44369/api/User/{userId}",token);
            var adress =await _address.GetUserAddressAsync($"https://localhost:44369/api/Address/user/{userId}");
            UserProfile userProfile = new UserProfile { Data = user.Data, Address = adress.Data };
            return View(userProfile);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
        {
            await _authService.UpdateAsync(userUpdateDto, "https://localhost:44369/api/User");
            return RedirectToAction("UserProfile", "User");
        }
    }
}
