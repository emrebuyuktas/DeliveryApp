using DeliveryApp.Web.HttpService;
using DeliveryApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _client;
        private readonly IApiService<Category> _service;

        public CategoryService(HttpClient client, IApiService<Category> service)
        {

            _client = client;
            _service = service;

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

        public async Task UpdateAsync(Category category, string url)
        {
            await _service.UpdateAsync(category, url, _client);
        }
    }
}
