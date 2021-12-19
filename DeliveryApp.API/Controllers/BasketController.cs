using DeliveryApp.Core.Entities.Concrete;
using DeliveryApp.Core.Repositories.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DeliveryApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basket;
        private readonly IHttpContextAccessor _contextAccessor;
        public BasketController(IBasketRepository basket, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, IHttpContextAccessor contextAccessor)
        {
            _basket = basket;
            _contextAccessor = contextAccessor;
        }
        [HttpGet]
        public async Task<IActionResult> GetBasket(string id)
        {
            var basket = await _basket.GetBasketAsync(id);
            Guid g = Guid.NewGuid();
            var user = _contextAccessor.HttpContext.User.Identity.Name;
            return Ok(basket ?? new CustomerBasket(g.ToString()));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBasket(CustomerBasket basket)
        {
            var updatedBasket = await _basket.UpdateBasketAsync(basket);
            return Ok(updatedBasket);
        }
        [HttpDelete]
        public async Task DeleteBasketAsync(string id)
        {
            await _basket.DeleteBasketAsync(id);
        }
    }
}
