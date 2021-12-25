using DeliveryApp.Core.Dtos;
using DeliveryApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Services
{
    public interface ICategoryService
    {
        Task<Category> GetAsync(string url);
        Task<CategoryWithProducts> GetWithProductsAsync(string url);
        Task<string> AddAsync(Category category, string url);
        Task DeleteAsync(string url, string id);
        Task UpdateAsync(ProductTypeUpdateDto productTypeUpdateDto, string url);
    }
}
