using DeliveryApp.Core.Dtos;
using DeliveryApp.Web.Areas.Admin.Models;
using DeliveryApp.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
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
        public async Task<IActionResult> AddProduct()
        {
            var categories = (await _category.GetAsync("https://localhost:44369/api/Types")).Data;
            var brands = (await _brand.GetAsync("https://localhost:44369/api/Brands")).Data;
            ProductAddViewModel productAddViewModel = new ProductAddViewModel {Categories=categories,Brands=brands };
            return View(productAddViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductAddDto productAddDto)
        {
            if(ModelState.IsValid)
            {
                var result = await _product.AddAsync(productAddDto, "https://localhost:44369/api/Products");
                if(result.ResultStatus==Shared.Result.ComplexTypes.ResultStatus.Error)
                {
                    return View(productAddDto);
                }
                return RedirectToAction("Index", "Product");
            }
            return View(productAddDto);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProduct()
        {
            var categories = (await _category.GetAsync("https://localhost:44369/api/Types")).Data;
            var brands = (await _brand.GetAsync("https://localhost:44369/api/Brands")).Data;
            ProductAddViewModel productAddViewModel = new ProductAddViewModel { Categories = categories, Brands = brands };
            return View(productAddViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductUpdateDto productUpdateDto)
        {
            if (ModelState.IsValid)
            {
                await _product.UpdateAsync(productUpdateDto, "https://localhost:44369/api/Products");
                return RedirectToAction("Index", "Product");
            }
            return View(productUpdateDto);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            await _product.DeleteAsync($"https://localhost:44369/api/Products/{productId}");
            return RedirectToAction("Index", "Product");
        }
    }
}
