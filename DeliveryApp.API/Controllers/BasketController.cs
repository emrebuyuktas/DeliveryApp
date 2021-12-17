using DeliveryApp.Core.Entities.Concrete;
using DeliveryApp.Core.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DeliveryApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basket;
        public BasketController(IBasketRepository basket)
        {
            _basket = basket;
        }
        [HttpGet]
        public async Task<IActionResult> GetBasket(string id)
        {
            var basket = await _basket.GetBasketAsync(id);
            return Ok(basket ?? new CustomerBasket(id));
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
