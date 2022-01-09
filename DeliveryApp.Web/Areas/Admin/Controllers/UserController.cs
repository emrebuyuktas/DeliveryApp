using DeliveryApp.Core.Dtos;
using DeliveryApp.Web.Areas.Admin.Models;
using DeliveryApp.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IAuthService _authService;

        public UserController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _authService.GetAllAsync("https://localhost:44369/api/User");
            return View(users);
        }
        [HttpPost]
        public async Task<IActionResult> RoleUpdate(UserUpdateViewModel userUpdateViewModel)
        {
            List<string> roles = new List<string>();
            roles.Add(userUpdateViewModel.Role);
            await _authService.AssignRoleAsync(new UserRoleAssignDto{UserId=userUpdateViewModel.Id.ToString(),
            Roles=roles
            }, "https://localhost:44369/api/Roles");
            return RedirectToAction("Index", "User");
        }
    }
}
