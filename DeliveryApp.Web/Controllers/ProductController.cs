using DeliveryApp.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _product;
        private readonly ICategoryService _category;
        public ProductController(IProductService product,ICategoryService category)
        {

            _product = product;
            _category = category;
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
        public async Task<IActionResult> Detail(int productId)
        {
            var model = await _product.GetAsync($"https://localhost:44369/api/Products/{productId}");

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Search(string keyword)
        {
            var model = await _product.GetAllAsync($"https://localhost:44369/api/Products/Search?keyword={keyword}&currentPage=1&pageSize=1000&isAscending=true");
            return View(model);
        }
    }
}
