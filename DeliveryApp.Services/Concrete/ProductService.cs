using AutoMapper;
using DeliveryApp.Core.Dtos;
using DeliveryApp.Core.Entities.Concrete;
using DeliveryApp.Core.Services.Abstract;
using DeliveryApp.Core.UnitOfWorks;
using DeliveryApp.Shared.Result;
using DeliveryApp.Shared.Result.Abstract;
using DeliveryApp.Shared.Result.ComplexTypes;
using DeliveryApp.Shared.Result.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliveryApp.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> Add(ProductAddDto productAddDto)
        {
            var product = _mapper.Map<Product>(productAddDto);
            await _unitOfWork.Products.AddAsync(product);
            return new Result(ResultStatus.Succes,$"{product.Name} has been added succesfully");
        }

        public async Task<IDataResult<ProductDto>> Get(int productId)
        {
            var product = await _unitOfWork.Products.GetAsync(x => x.Id == productId, x => x.ProductBrand, x => x.ProductType);
            var productToReturnDto = _mapper.Map<ProductDto>(product);
            return new DataResult<ProductDto>(ResultStatus.Succes, productToReturnDto);
        }

        public async Task<IDataResult<IList<ProductDto>>> GetAll()
        {
            var products = await _unitOfWork.Products.GetAllAsync(null, x => x.ProductBrand, x => x.ProductType);
            var productsToList = _mapper.Map<IList<ProductDto>>(products);
            return new DataResult<IList<ProductDto>>(ResultStatus.Succes,productsToList);
        }

        public async Task<IResult> Update(ProductUpdateDto updateDto)
        {
            var product = _mapper.Map<Product>(updateDto);
            await _unitOfWork.Products.UpdateAsync(product);
            return new Result(ResultStatus.Succes);
        }
    }
}
