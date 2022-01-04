﻿
using DeliveryApp.Core.Dtos;
using DeliveryApp.Web.HttpService;
using DeliveryApp.Web.Models;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Services
{
    public class ProductService:IProductService
    {
        private readonly HttpClient _client;
        private readonly IApiService<ProductList> _service;
        private readonly IApiService<Product> _singleProduct;
        private readonly IApiService<ProductUpdateDto> _updateService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ProductService(HttpClient client, IApiService<ProductList> service, IApiService<ProductUpdateDto> updateService, IApiService<Product> singleProduct, IHttpContextAccessor httpContextAccessor)
        {
            _client = client;
            _service = service;
            _updateService = updateService;
            _singleProduct = singleProduct;
            _httpContextAccessor = httpContextAccessor;

        }

        public async Task<string> AddAsync(ProductList product,string url)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_httpContextAccessor.HttpContext.Request
        .Cookies["DeliveryApp"]);
            return await _service.AddAsync(product,url,_client);
        }

        public async Task DeleteAsync(string url, string id)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_httpContextAccessor.HttpContext.Request
        .Cookies["DeliveryApp"]);
            await _service.DeleteAsync(url + id, _client);
        }

        public async Task<ProductList> GetAllAsync(string url)
        {
            return await _service.GetAsync(url, _client);
        }

        public async Task<Product> GetAsync(string url)
        {
            return await _singleProduct.GetAsync(url, _client);
        }

        public async Task UpdateAsync(ProductUpdateDto productUpdateDto, string url)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_httpContextAccessor.HttpContext.Request
        .Cookies["DeliveryApp"]);
            await _updateService.UpdateAsync(productUpdateDto, url, _client);
        }
    }
}
