using DeliveryApp.Core.Dtos;
using DeliveryApp.Web.Models;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Services
{
    public interface IBrandService
    {
        Task<Brand> GetAsync(string url);
        Task<BrandWithProducts> GetWithProductsAsync(string url);
        Task<string> AddAsync(Brand brand, string url);
        Task DeleteAsync(string url, string id);
        Task UpdateAsync(ProductBrandUpdateDto productBrandUpdateDto, string url);
    }
}
