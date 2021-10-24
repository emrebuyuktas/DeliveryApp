﻿using DeliveryApp.Core.Dtos;
using DeliveryApp.Core.Services.Abstract;
using DeliveryApp.Shared.Result.ComplexTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly IProductTypeService _iproductTypeService;

        public TypesController(IProductTypeService iproductTypeService)
        {
            _iproductTypeService = iproductTypeService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Type(int id)
        {
            var product = await _iproductTypeService.GetAsync(id);
            return Ok(product);
        }
        [HttpGet]
        public async Task<IActionResult> Type()
        {
            var products = await _iproductTypeService.GetAllAsync();
            return Ok(products);
        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductTypeAddDto productTypeAddDto)
        {
            var type = await _iproductTypeService.AddAsync(productTypeAddDto);
            return Created(string.Empty, type);
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductTypeUpdateDto productTypeUpdateDto)
        {
            var response = await _iproductTypeService.UpdateAsync(productTypeUpdateDto);
            if (response.ResultStatus == ResultStatus.Succes)
                return NoContent();
            return BadRequest(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var response = await _iproductTypeService.DeleteAsync(id);
            if (response.ResultStatus == ResultStatus.Succes)
                return NoContent();
            return BadRequest(response);
        }
    }
}
