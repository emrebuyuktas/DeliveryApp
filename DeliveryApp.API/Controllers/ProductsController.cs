using DeliveryApp.Core.Entities.Concrete;
using DeliveryApp.Core.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DeliveryApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Product(int id)
        {
            var product= await _unitOfWork.Products.GetAsync(x => x.Id == id, x=> x.ProductBrand,x => x.ProductType);
            return Ok(product);
        }
        [HttpGet]
        public async Task<IActionResult> Product()
        {
            var products = await _unitOfWork.Products.GetAllAsync(null,x =>x.ProductBrand, x => x.ProductType);
            return Ok(products);
        }
        [HttpPost]
        public async Task<IActionResult> Save(Product product)
        {
            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.CommitAsync();
            return Created(string.Empty, product);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Product product)
        {
            await _unitOfWork.Products.UpdateAsync(product);
            await _unitOfWork.CommitAsync();
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(Product product)
        {
            await _unitOfWork.Products.DeleteAsync(product);
            await _unitOfWork.CommitAsync();
            return NoContent();
        }
    }
}
