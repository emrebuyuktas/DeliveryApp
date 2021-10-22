using DeliveryApp.Core.Entities.Concrete;

namespace DeliveryApp.Core.Repositories.Abstract
{
    public interface IProductRepository:IRepository<Product>
    {
        IProductRepository Products { get; }
    }
}
