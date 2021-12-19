using DeliveryApp.Core.Entities.Concrete;
using DeliveryApp.Core.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DeliveryApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<User> _userManager;
        public OrderController(IOrderService orderService, IHttpContextAccessor contextAccessor, UserManager<User> userManager)
        {
            _orderService = orderService;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
        }
        [HttpPost("{id}")]
        public async Task<ActionResult<Order>> CreateOrder(string id)
        {
            var userEmail = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
            var userId = await _userManager.FindByEmailAsync(userEmail);
            var order = await _orderService.CreateOrderAsync(id, userEmail);
            return Ok(order);
        }
    }
}
