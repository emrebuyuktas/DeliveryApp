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
    public class ProductBrandService : IProductBrandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductBrandService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> AddAsync(ProductBrandAddDto brandAddDto)
        {
            var brand = _mapper.Map<ProductBrand>(brandAddDto);
            await _unitOfWork.Products.AddAsync(brand);
            await _unitOfWork.CommitAsync();
            return new Result(ResultStatus.Succes,$"{brand.Name} has been added successfully");
        }

        public async Task<IDataResult<ProductBrandDto>> GetAsync(int brandId)
        {
            var brand = await _unitOfWork.Products.GetAsync(x => x.Id == brandId, x => x.ProductService, x => x.ProductType); //bakılması gerekiyor.
            if (brand == null)
                return new DataResult<BrandDto>(ResultStatus.Error, "No products found with specified criteria",null);
            var brandToReturnDto = _mapper.Map<BrandDto>(brand);                                                            //bakılması gerekiyor.
            return new DataResult<BrandDto>(ResultStatus.Succes, brandToReturnDto);
        }

        public async Task<IDataResult<IList<ProductBrandDto>>> GetAllAsync()
        {
            var brand = await _unitOfWork.Products.GetAllAsync(null, x => x.ProductService, x => x.ProductType);
            if (brand == null)
                return new DataResult<IList<BrandDto>>(ResultStatus.Error, "No products found with specified criteria", null);
            var brandToList = _mapper.Map<IList<ProductDto>>(brand);
            return new DataResult<IList<BrandDto>>(ResultStatus.Succes,brandToList);
        }

        public async Task<IResult> UpdateAsync(ProductBrandUpdateDto brandUpdateDto)
        {
            var brand = _mapper.Map<Brand>(brandUpdateDto);
            await _unitOfWork.Brand.UpdateAsync(brand);
            await _unitOfWork.CommitAsync();
            return new Result(ResultStatus.Succes,$"{brand.Name} shas been updated successfully");
        }
        public async Task<IResult> DeleteAsync(int id)
        {
            var brand = await _unitOfWork.Brand.GetAsync(x => x.Id == id, x => x.ProductService, x => x.ProductType);
            if (brand == null)
                return new Result(ResultStatus.Error, "No products found with specified criteria");
            await _unitOfWork.Brand.DeleteAsync(brand);
            await _unitOfWork.CommitAsync();
            return new Result(ResultStatus.Succes, $"{brand.Name} shas been deleted successfully");
        }
    }
}
