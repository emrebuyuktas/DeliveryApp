using DeliveryApp.Core.Dtos;
using DeliveryApp.Shared.Result;
using DeliveryApp.Shared.Result.Abstract;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliveryApp.Core.Services.Abstract
{
    public interface IProductService
    {
        Task<IDataResult<ProductDto>> Get(int productId);
        Task<IDataResult<IList<ProductDto>>> GetAll();
        Task<IResult> Add(ProductAddDto productAddDto);
        Task<IResult> Update(ProductUpdateDto updateDto);
    }
}
