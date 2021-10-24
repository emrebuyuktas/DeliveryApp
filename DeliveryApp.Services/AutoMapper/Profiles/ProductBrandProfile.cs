using AutoMapper;
using DeliveryApp.Core.Dtos;
using DeliveryApp.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Services.AutoMapper.Profiles
{
    public class ProductBrandProfile:Profile
    {
        public ProductBrandProfile()
        {
            CreateMap<ProductBrand, ProductBrandDto>().ReverseMap();

            CreateMap<ProductBrand, ProductBrandUpdateDto>().ReverseMap();
            CreateMap<ProductBrand, ProductBrandAddDto>().ReverseMap();
        }
    }
}
