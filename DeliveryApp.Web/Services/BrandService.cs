using DeliveryApp.Web.HttpService;
using DeliveryApp.Web.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Services
{
    public class BrandService : IBrandService
    {
        private readonly HttpClient _client;
        private readonly IApiService<Brand> _service;

        public BrandService(IApiService<Brand> service, HttpClient client)
        {
            _service = service;
            _client = client;
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
        
        public async Task UpdateAsync(Brand brand, string url)
        {
            await _service.UpdateAsync(brand, url, _client);
        }

        
    }
}
