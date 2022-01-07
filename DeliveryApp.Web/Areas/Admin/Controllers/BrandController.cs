using DeliveryApp.Core.Dtos;
using DeliveryApp.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Areas.Admin.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService _brand;

        public BrandController(IBrandService brand)
        {
            _brand = brand;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _brand.GetAsync("https://localhost:44369/api/Brands");
            return View(model);
        }
        [HttpGet]
        public IActionResult AddBrand()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(ProductBrandAddDto productBrandAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _brand.AddAsync(productBrandAddDto, "https://localhost:44369/api/Types");
                if (result.ResultStatus == Shared.Result.ComplexTypes.ResultStatus.Error)
                {
                    return View(productBrandAddDto);
                }
                return RedirectToAction("Index", "Brand");
            }
            return View(productBrandAddDto);
        }
        [HttpGet]
        public IActionResult UpdateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductBrandUpdateDto productBrandUpdateDto)
        {
            if (ModelState.IsValid)
            {
                await _brand.UpdateAsync(productBrandUpdateDto, "https://localhost:44369/api/Types");
                return RedirectToAction("Index", "Brand");
            }
            return View(productBrandUpdateDto);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteProduct(int categoryId)
        {
            await _brand.DeleteAsync($"https://localhost:44369/api/Types/{categoryId}");
            return RedirectToAction("Index", "Brand");
        }
    }
}
