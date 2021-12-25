using DeliveryApp.Core.Dtos;
using DeliveryApp.Web.HttpService;
using DeliveryApp.Web.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _client;
        private readonly IApiService<Category> _service;
        private readonly IApiService<ProductTypeUpdateDto> _updateService;
        private readonly IApiService<CategoryWithProducts> _categories;

        public CategoryService(HttpClient client, IApiService<Category> service, IApiService<ProductTypeUpdateDto> updateService, IApiService<CategoryWithProducts> categories)
        {

            _client = client;
            _service = service;
            _updateService = updateService;
            _categories = categories;
        }

        public async Task<string> AddAsync(Category category, string url)
        {
            return await _service.AddAsync(category, url, _client);
        }

        public async Task DeleteAsync(string url, string id)
        {
            await _service.DeleteAsync(url + id, _client);
        }

        public async Task<Category> GetAsync(string url)
        {
            return await _service.GetAsync(url, _client);
        }

        public Task<CategoryWithProducts> GetWithProductsAsync(string url)
        {
           return _categories.GetAsync(url, _client);
            
        }

        public async Task UpdateAsync(ProductTypeUpdateDto productTypeUpdateDto, string url)
        {
            await _updateService.UpdateAsync(productTypeUpdateDto, url, _client);
        }
    }
}
