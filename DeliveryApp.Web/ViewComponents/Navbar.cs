using Microsoft.AspNetCore.Mvc;
using DeliveryApp.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeliveryApp.Web.Services;

namespace DeliveryApp.Web.ViewComponents
{
    public class Navbar : ViewComponent
    {
        private readonly IAuthService _auth;

        public Navbar(IAuthService auth)
        {
            _auth = auth;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var auth = await _auth.GetAsync($"https://localhost:44369/api/User/1");

            return View(auth);
        }


    }
}
