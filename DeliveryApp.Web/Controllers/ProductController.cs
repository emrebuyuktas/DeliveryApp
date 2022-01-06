using DeliveryApp.Core.Dtos;
using DeliveryApp.Web.Models;
using DeliveryApp.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _product;
        private readonly ICategoryService _category;
        private readonly IBrandService _brand;
        public ProductController(IProductService product, ICategoryService category, IBrandService brand)
        {

            _product = product;
            _category = category;
            _brand = brand;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _product.GetAsync("https://localhost:44369/api/Products/");
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> CategoryWithProducts(int categoryId)
        {
            var model = await _category.GetWithProductsAsync($"https://localhost:44369/api/Types/{categoryId}/products");
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> BrandWithProducts(int brandId)
        {
            var model = await _brand.GetWithProductsAsync($"https://localhost:44369/api/Brands/{brandId}/products");
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int productId)
        {
            var model = await _product.GetAsync($"https://localhost:44369/api/Products/{productId}");
            var recomended = await _product.GetAllAsync("https://localhost:44369/api/Products?productTypeId=1&currentPage=1&pageSize=3&isAscending=true");
            ProductWithRecomendedModelView modelview = new ProductWithRecomendedModelView
            {
                Product = model.Data,
                RecomendedProducts = recomended.Data
            };
            return View(modelview);
        }
        [HttpGet]
        public async Task<IActionResult> Search(string keyword)
        {
            var model = await _product.GetAllAsync($"https://localhost:44369/api/Products/Search?keyword={keyword}&currentPage=1&pageSize=1000&isAscending=true");
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRating(Rating rating)
        {
            await _product.UpdateRating(rating, "https://localhost:44369/api/Products/rating");
            return RedirectToAction("Index", "Home");
        }
    }
}
