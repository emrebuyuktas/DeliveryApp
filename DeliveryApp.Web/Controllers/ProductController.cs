using DeliveryApp.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IActionResult> CategoryWithProducts(int id)
        {
            var model = await _category.GetAsync($"https://localhost:44369/api/Types/{id}/products");
           
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int productId)
        {
            var model = await _product.GetAsync($"https://localhost:44369/api/Products/{productId}");

            return View(model);
        }


    }
}
