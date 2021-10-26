using DeliveryApp.Core.Dtos;
using DeliveryApp.Core.Services.Abstract;
using DeliveryApp.Shared.Result.ComplexTypes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        [HttpGet("{id}/products")]
        public async Task<IActionResult> TypeWithProducts(int id)
        {
            var product = await _iproductTypeService.GetWithProducts(id);
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
        [HttpPost("types")]
        public async Task<IActionResult> Save(IList<ProductTypeAddDto> productTypeAddDtos)
        {
            var types = await _iproductTypeService.AddRangeAsync(productTypeAddDtos);
            return Created(string.Empty, types);
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
