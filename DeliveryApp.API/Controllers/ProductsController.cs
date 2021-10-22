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

        public ProductsController()
        {

        }
        [HttpGet("{id}")]
        public async  Task<IActionResult> Product(int id)
        {
            var product= await _unitOfWork.Products.GetAsync(x => x.Id == id);
            return Ok(product);
        }
    }
}
