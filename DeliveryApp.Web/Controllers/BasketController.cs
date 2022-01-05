using DeliveryApp.Core.Entities.Concrete;
using DeliveryApp.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;
        public BasketController(IBasketService basketService, IProductService productService)
        {
            _basketService = basketService;
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var basket = await _basketService.GetAsync("https://localhost:44369/api/Basket");
            return View(basket);
        }
        [HttpPost]
        public async Task<IActionResult> AddSingle(int productId)
        {
            var basket = await _basketService.GetAsync("https://localhost:44369/api/Basket");
            var product = await _productService.GetAsync($"https://localhost:44369/api/Products/{productId}");
            basket.Items.Add(new BasketItem
            {
                Id = product.Data.Id,
                Name = product.Data.Name,
                Price = product.Data.Price,
                Quantity=1,
                PictureUrl=product.Data.PictureUrl,
                ProductBrand=product.Data.ProductBrand,
                ProductType=product.Data.ProductType
            }) ;
            await _basketService.UpdateAsync(basket, "https://localhost:44369/api/Basket");
            return View(basket);
        }
        [HttpPost]
        public async Task<IActionResult> Add(BasketItem item)
        {
            var basket = await _basketService.GetAsync("https://localhost:44369/api/Basket");
            basket.Items.Add(item);
            await _basketService.UpdateAsync(basket, "https://localhost:44369/api/Basket");
            return View(basket);
        }

    }
}
