using DeliveryApp.Core.Dtos;
using DeliveryApp.Core.Services.Abstract;
using DeliveryApp.Shared.Result.ComplexTypes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DeliveryApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IProductBrandService _iproductBrandService;

        public BrandsController(IProductBrandService iproductBrandService)
        {
            _iproductBrandService = iproductBrandService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Brand(int id)
        {
            var brand = await _iproductBrandService.GetAsync(id);
            return Ok(brand);
        }
        [HttpGet]
        public async Task<IActionResult> Brand()
        {
            var brands = await _iproductBrandService.GetAllAsync();
            return Ok(brands);
        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductBrandAddDto productBrandAddDto)
        {
            var product = await _iproductBrandService.AddAsync(productBrandAddDto);
            return Created(string.Empty, product);
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductBrandUpdateDto productBrandUpdateDto)
        {
            var response = await _iproductBrandService.UpdateAsync(productBrandUpdateDto);
            if (response.ResultStatus == ResultStatus.Succes)
                return NoContent();
            return BadRequest(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var response = await _iproductBrandService.DeleteAsync(id);
            if (response.ResultStatus == ResultStatus.Succes)
                return NoContent();
            return BadRequest(response);
        }
    }
}
