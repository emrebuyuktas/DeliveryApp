using DeliveryApp.Core.Dtos;
using DeliveryApp.Web.HttpService;
using DeliveryApp.Web.Models;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Services
{
    public class BrandService : IBrandService
    {
        private readonly HttpClient _client;
        private readonly IApiService<Brand> _service;
        private readonly IApiService<ProductBrandUpdateDto> _update;
        private readonly IApiService<BrandWithProducts> _brands;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BrandService(IApiService<Brand> service, HttpClient client, IApiService<ProductBrandUpdateDto> update, IApiService<BrandWithProducts> brands, IHttpContextAccessor httpContextAccessor)
        {
            _service = service;
            _client = client;
            _update = update;
            _brands = brands;
            _httpContextAccessor = httpContextAccessor;
            var token = _httpContextAccessor.HttpContext.Request
.Cookies["DeliveryApp"];
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        }

        public async Task<string> AddAsync(Brand brand, string url)
        {
            return await _service.AddAsync(brand, url, _client);
        }

        public async Task DeleteAsync(string url, string id)
        {
            await _service.DeleteAsync(url + id, _client);
        }

        public async Task<Brand> GetAsync(string url)
        {
            return await _service.GetAsync(url, _client);
        }

        public async Task<BrandWithProducts> GetWithProductsAsync(string url)
        {
            return await _brands.GetAsync(url, _client);
        }

        public async Task UpdateAsync(ProductBrandUpdateDto productBrandUpdateDto, string url)
        {
            await _update.UpdateAsync(productBrandUpdateDto, url, _client);
        }

        
    }
}
