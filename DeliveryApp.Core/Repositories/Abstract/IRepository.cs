using DeliveryApp.Core.Entities.Abstaract;

namespace DeliveryApp.Core.Repositories.Abstract
{
    public interface IRepository<T> where T: class, IEntity, new()
    {

    }
}
