using DeliveryApp.Core.Entities.Concrete;
using DeliveryApp.Core.Repositories.Abstract;
using DeliveryApp.Data.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.Data.Repositories
{
    class ProductBrandRepository: RepositoryBase<ProductBrand>, IProductBrandRepository
    {
        public ProductBrandRepository(AppDbContext context):base(context)
        {

        }
    }
}
