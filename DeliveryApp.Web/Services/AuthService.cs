using DeliveryApp.Web.HttpService;
using DeliveryApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Services
{
    public class AuthService : IAuthService
    {

        private readonly HttpClient _client;
        private readonly IApiService<Auth> _service;


        public AuthService(IApiService<Auth> service, HttpClient client)
        {

            _service = service;
            _client = client;

        }

        public async Task<string> AddAsync(Auth auth, string url)
        {
            return await _service.AddAsync(auth, url, _client);
        }

        public async Task DeleteAsync(string url, string id)
        {
            await _service.DeleteAsync(url + id, _client);
        }

        public async Task<Auth> GetAsync(string url)
        {
            return await _service.GetAsync(url, _client);
        }

        public async Task UpdateAsync(Auth auth, string url)
        {
            await _service.UpdateAsync(auth, url, _client);
        }
    }
}
