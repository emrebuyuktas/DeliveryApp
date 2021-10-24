using DeliveryApp.Core.Dtos;
using DeliveryApp.Core.Services.Abstract;
using DeliveryApp.Core.UnitOfWorks;
using DeliveryApp.Shared.Result.ComplexTypes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DeliveryApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _iproductService;

        public ProductsController(IProductService iproductService)
        {
            _iproductService = iproductService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Product(int id)
        {
            var product = await _iproductService.Get(id);
            return Ok(product);
        }
        [HttpGet]
        public async Task<IActionResult> Product()
        {
            var products = await _iproductService.GetAll();
            return Ok(products);
        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductAddDto productAddDto)
        {
            var product=await _iproductService.Add(productAddDto);
            return Created(string.Empty, product);
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
            var response=await _iproductService.Update(productUpdateDto);
            if(response.ResultStatus == ResultStatus.Succes)
                return NoContent();
            return BadRequest(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var response=await _iproductService.DeleteAsync(id);
            if (response.ResultStatus == ResultStatus.Succes)
                return NoContent();
            return BadRequest(response);
        }
    }
}
