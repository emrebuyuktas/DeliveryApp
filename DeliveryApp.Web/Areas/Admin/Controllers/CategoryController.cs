using DeliveryApp.Core.Dtos;
using DeliveryApp.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _category;

        public CategoryController(ICategoryService category)
        {
            _category = category;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _category.GetAsync("https://localhost:44369/api/Types");
            return View(model);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(ProductTypeAddDto productTypeAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _category.AddAsync(productTypeAddDto, "https://localhost:44369/api/Types");
                if (result.ResultStatus == Shared.Result.ComplexTypes.ResultStatus.Error)
                {
                    return View(productTypeAddDto);
                }
                return RedirectToAction("Index", "Category");
            }
            return View(productTypeAddDto);
        }
        [HttpGet]
        public IActionResult UpdateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductTypeUpdateDto productTypeUpdate)
        {
            if (ModelState.IsValid)
            {
                await _category.UpdateAsync(productTypeUpdate, "https://localhost:44369/api/Types");
                return RedirectToAction("Index", "Category");
            }
            return View(productTypeUpdate);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteProduct(int categoryId)
        {
            await _category.DeleteAsync($"https://localhost:44369/api/Types/{categoryId}");
            return RedirectToAction("Index", "Category");
        }
    }
}
