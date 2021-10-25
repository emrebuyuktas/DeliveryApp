using AutoMapper;
using DeliveryApp.Core.Dtos;
using DeliveryApp.Core.Entities.Concrete;

namespace DeliveryApp.Services.AutoMapper.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
           .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
           .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name));

            CreateMap<Product, ProductUpdateDto>().ReverseMap();
            CreateMap<Product, ProductAddDto>().ReverseMap();
            CreateMap<ProductType, ProductBrandWithProductsDto>();


        }
    }
}
