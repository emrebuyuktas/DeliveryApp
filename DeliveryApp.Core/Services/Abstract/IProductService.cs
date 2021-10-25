﻿using DeliveryApp.Core.Dtos;
using DeliveryApp.Shared.Result;
using DeliveryApp.Shared.Result.Abstract;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliveryApp.Core.Services.Abstract
{
    public interface IProductService
    {
        Task<IDataResult<ProductDto>> GetAsync(int productId);
        Task<IDataResult<IList<ProductDto>>> GetAllAsync();
        Task<IDataResult<ProductListDto>> GetAllWithPagesAsync(int? productTypeId,int? productBrandId,int currentPage,int pageSize=5,bool isAscending=false);
        Task<IResult> AddAsync(ProductAddDto productAddDto);
        Task<IResult> UpdateAsync(ProductUpdateDto updateDto);
        Task<IResult> DeleteAsync(int id);
    }
}
