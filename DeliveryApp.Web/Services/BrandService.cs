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

        public async Task<Brand> GetAsync(string url)
        {
            return await _service.GetAsync(url, _client);
        }
    }
}
