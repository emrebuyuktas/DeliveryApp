using DeliveryApp.Core.Entities.Concrete;
using DeliveryApp.Core.Repositories.Abstract;

namespace DeliveryApp.Data.Repositories
{
    public class ProductRepository:RepositoryBase<Product>, IProductRepository
    {
    }
}
