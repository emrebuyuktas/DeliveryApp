using DeliveryApp.Web.HttpService;
using DeliveryApp.Web.Models;
using DeliveryApp.Web.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Services
{
    public class AddressService : IAddressService
    {
        private readonly IApiService<UserAddress> _singleAddress;
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AddressService(IApiService<UserAddress> singleAddress, HttpClient client, IHttpContextAccessor httpContextAccessor)
        {
            _singleAddress = singleAddress;
            _client = client;
            _httpContextAccessor = httpContextAccessor;
            var token = _httpContextAccessor.HttpContext.Request
.Cookies["DeliveryApp"];
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

        }

        public Task<string> AddAsync(ProductList product, string url)
        {
            throw new NotImplementedException();
        }

        public Task<Address> GetAllAsync(string url)
        {
            throw new NotImplementedException();
        }

        public async Task<UserAddress> GetUserAddressAsync(string url)
        {
            var response = await _singleAddress.GetAsync(url,_client);
            return response;
        }
    }
}
