using DeliveryApp.Web.Models;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Services
{
    public interface IProductService
    {
        Task<Product> GetAsync(string url);
        Task<string> AddAsync(Product product, string url);
    }
}
