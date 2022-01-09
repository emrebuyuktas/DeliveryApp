﻿using DeliveryApp.Core.Dtos;
using DeliveryApp.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
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
        public async Task<IActionResult> AddBrand(ProductBrandAddDto productBrandAddDto)
        {
            if (ModelState.IsValid)
            {
                await _brand.AddAsync(productBrandAddDto, "https://localhost:44369/api/Brands");
                return RedirectToAction("Index", "Brand");
            }
            return View(productBrandAddDto);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateBrand(int brandId)
        {
            var brand = await _brand.GetBrandAsync($"https://localhost:44369/api/Brands/{brandId}");
            ProductBrandUpdateDto productBrandUpdateDto = new ProductBrandUpdateDto { Id = brand.Data.Id, Name = brand.Data.Name };
            return View(productBrandUpdateDto);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBrand(ProductBrandUpdateDto productBrandUpdateDto)
        {
            if (ModelState.IsValid)
            {
                await _brand.UpdateAsync(productBrandUpdateDto, "https://localhost:44369/api/Brands");
                return RedirectToAction("Index", "Brand");
            }
            return View(productBrandUpdateDto);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteBrand(int brandId)
        {
            await _brand.DeleteAsync($"https://localhost:44369/api/Brands/{brandId}");
            return RedirectToAction("Index", "Brand");
        }
    }
}
