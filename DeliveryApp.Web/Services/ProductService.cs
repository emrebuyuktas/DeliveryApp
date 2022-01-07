﻿
using DeliveryApp.Core.Dtos;
using DeliveryApp.Shared.Result.Concrete;
using DeliveryApp.Web.HttpService;
using DeliveryApp.Web.Models;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Services
{
    public class ProductService:IProductService
    {
        private readonly HttpClient _client;
        private readonly IApiService<ProductList> _service;
        private readonly IApiService<ProductAddDto> _add;
        private readonly IApiService<Search> _search;
        private readonly IApiService<Product> _singleProduct;
        private readonly IApiService<ProductUpdateDto> _updateService;
        private readonly IApiService<Rating> _updateRating;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ProductService(HttpClient client, IApiService<ProductList> service, IApiService<ProductUpdateDto> updateService, IApiService<Product> singleProduct, IHttpContextAccessor httpContextAccessor, IApiService<Rating> updateRating, IApiService<Search> search, IApiService<ProductAddDto> add)
        {
            _client = client;
            _service = service;
            _updateService = updateService;
            _singleProduct = singleProduct;
            _httpContextAccessor = httpContextAccessor;
            _updateRating = updateRating;
            _search = search;
            _add = add;
        }

        public async Task<Result> AddAsync(ProductAddDto productAddDto,string url)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_httpContextAccessor.HttpContext.Request
        .Cookies["DeliveryApp"]);
            return JsonSerializer.Deserialize<Result>(await _add.AddAsync(productAddDto, url, _client), new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
        }

        public async Task DeleteAsync(string url)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_httpContextAccessor.HttpContext.Request
        .Cookies["DeliveryApp"]);
            await _service.DeleteAsync(url, _client);
        }

        public async Task<ProductList> GetAllAsync(string url)
        {
            return await _service.GetAsync(url, _client);
        }
        public async Task<Product> GetAsync(string url)
        {
            return await _singleProduct.GetAsync(url, _client);
        }
        public async Task<ProductListDto> SearchAsync(string url)
        {
            return (await _search.GetAsync(url, _client)).Data;
        }

        public async Task UpdateAsync(ProductUpdateDto productUpdateDto, string url)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_httpContextAccessor.HttpContext.Request
        .Cookies["DeliveryApp"]);
            await _updateService.UpdateAsync(productUpdateDto, url, _client);
        }

        public async Task UpdateRating(Rating rating,string url)
        {
            await _updateRating.UpdateAsync(rating, url, _client);
        }
    }
}
