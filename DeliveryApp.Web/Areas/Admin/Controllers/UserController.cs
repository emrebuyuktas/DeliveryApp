using DeliveryApp.Core.Dtos;
using DeliveryApp.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Areas.Admin.Controllers
{
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
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RoleUpdate(UserRoleAssignDto userRoleAssignDto)
        {
            await _authService.AssignRoleAsync(userRoleAssignDto,"https://localhost:44369/api/User");
            return RedirectToAction("Index", "User");
        }
    }
}
