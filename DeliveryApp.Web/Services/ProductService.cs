
using DeliveryApp.Web.HttpService;
using DeliveryApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Services
{
    public class ProductService:IProductService
    {
        private readonly HttpClient _client;
        private readonly IApiService<Product> _service;
        public ProductService(HttpClient client, IApiService<Product> service)
        {
            _client = client;
            _service = service;
        }

        public async Task<string> AddAsync(Product product,string url)
        {
            return await _service.AddAsync(product,url,_client);
        }

        public async Task<Product> GetAsync(string url)
        {
            return await _service.GetAsync(url, _client);
        }
    }
}
