using DeliveryApp.Core.Entities.Abstaract;
using DeliveryApp.Core.Repositories.Abstract;

namespace DeliveryApp.Data.Repositories
{
    public class RepositoryBase<T>:IRepository<T> where T : class, IEntity, new()
    {
    }
}
