
using DeliveryApp.Core.Dtos;
using DeliveryApp.Web.HttpService;
using DeliveryApp.Web.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Services
{
    public class ProductService:IProductService
    {
        private readonly HttpClient _client;
        private readonly IApiService<Product> _service;
        private readonly IApiService<ProductUpdateDto> _updateService;
        public ProductService(HttpClient client, IApiService<Product> service, IApiService<ProductUpdateDto> updateService)
        {
            _client = client;
            _service = service;
            _updateService = updateService;
        }

        public async Task<string> AddAsync(Product product,string url)
        {
            return await _service.AddAsync(product,url,_client);
        }

        public async Task DeleteAsync(string url, string id)
        {
            await _service.DeleteAsync(url + id, _client);
        }

        public async Task<Product> GetAsync(string url)
        {
            return await _service.GetAsync(url, _client);
        }

        public async Task UpdateAsync(ProductUpdateDto productUpdateDto, string url)
        {
            await _updateService.UpdateAsync(productUpdateDto, url, _client);
        }
    }
}
