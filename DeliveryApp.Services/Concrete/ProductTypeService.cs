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
    public class ProductTypeService : IProductTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> AddAsync(ProductTypeAddDto typeAddDto)
        {
            var type = _mapper.Map<ProductType>(typeAddDto);
            await _unitOfWork.Type.AddAsync(type);
            await _unitOfWork.CommitAsync();
            return new Result(ResultStatus.Succes,$"{type.Name} has been added successfully");
        }

        public async Task<IDataResult<ProductTypeDto>> GetAsync(int typeId)
        {
            var type = await _unitOfWork.Type.GetAsync(x => x.Id == typeId, x => x.ProductService, x => x.ProductBrand); //bakılması gerekiyor.
            if (type == null)
                return new DataResult<TypeDto>(ResultStatus.Error, "No products found with specified criteria",null);
            var typeToReturnDto = _mapper.Map<TypeDto>(type);                                                            //bakılması gerekiyor.
            return new DataResult<TypeDto>(ResultStatus.Succes, typeToReturnDto);
        }

        public async Task<IDataResult<IList<ProductTypeDto>>> GetAllAsync()
        {
            var type = await _unitOfWork.Type.GetAllAsync(null, x => x.ProductService, x => x.ProductBrand);
            if (type == null)
                return new DataResult<IList<TypeDto>>(ResultStatus.Error, "No products found with specified criteria", null);
            var typeToList = _mapper.Map<IList<ProductTypeDto>>(type);
            return new DataResult<IList<TypeDto>>(ResultStatus.Succes,typeToList);
        }

        public async Task<IResult> UpdateAsync(ProductTypeUpdateDto updateTypeDto)
        {
            var type = _mapper.Map<Type>(updateTypeDto);
            await _unitOfWork.Type.UpdateAsync(type);
            await _unitOfWork.CommitAsync();
            return new Result(ResultStatus.Succes,$"{type.Name} shas been updated successfully");
        }
        public async Task<IResult> DeleteAsync(int id)
        {
            var type = await _unitOfWork.Type.GetAsync(x => x.Id == id, x => x.ProductService, x => x.ProductBrand);
            if (type == null)
                return new Result(ResultStatus.Error, "No products found with specified criteria");
            await _unitOfWork.Type.DeleteAsync(type);
            await _unitOfWork.CommitAsync();
            return new Result(ResultStatus.Succes, $"{type.Name} shas been deleted successfully");
        }
    }
}
