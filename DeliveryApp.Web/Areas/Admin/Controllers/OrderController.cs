using DeliveryApp.Core.Dtos;
using DeliveryApp.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = await _orderService.GetOrdersAsync("https://localhost:44369/api/Order");
            return View(orders);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateOrder(OrderUpdateDto orderUpdateDto)
        {
            await _orderService.UpdateOrderAsync(orderUpdateDto,"https://localhost:44369/api/Order");
            return RedirectToAction("Index","Order");
        }
    }
}
