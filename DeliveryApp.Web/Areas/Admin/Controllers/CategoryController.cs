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
                await _category.AddAsync(productTypeAddDto, "https://localhost:44369/api/Types");
                return RedirectToAction("Index", "Category");
            }
            return View(productTypeAddDto);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int categoryId)
        {
            var category = await _category.GetCategorAsync($"https://localhost:44369/api/Types/{categoryId}");
            CategoryUpdateViewModel categoryUpdateViewModel = new CategoryUpdateViewModel { ProductTypeDto = category.Data, ProductTypeUpdateDto = null };
            return View(categoryUpdateViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(ProductTypeUpdateDto productTypeUpdate)
        {
            if (ModelState.IsValid)
            {
                await _category.UpdateAsync(productTypeUpdate, "https://localhost:44369/api/Types");
                return RedirectToAction("Index", "Category");
            }
            CategoryUpdateViewModel categoryUpdateViewModel = new CategoryUpdateViewModel { ProductTypeDto = null, ProductTypeUpdateDto = productTypeUpdate };
            return View(categoryUpdateViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            await _category.DeleteAsync($"https://localhost:44369/api/Types/{categoryId}");
            return RedirectToAction("Index", "Category");
        }
    }
}
