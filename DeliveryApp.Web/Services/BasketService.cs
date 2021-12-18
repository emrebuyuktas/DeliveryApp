﻿using DeliveryApp.Web.HttpService;
using DeliveryApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _client;
        private readonly IApiService<Basket> _service;

        public BasketService(IApiService<Basket> service, HttpClient client)
        {
            _client = client;
            _service = service;

        }

        public async Task<string> AddAsync(Basket basket, string url)
        {
            return await _service.AddAsync(basket, url, _client);
        }

        public async Task DeleteAsync(string url, string id)
        {
            await _service.DeleteAsync(url + id, _client);
        }

        public async Task<Basket> GetAsync(string url)
        {
            return await _service.GetAsync(url, _client);
        }

        public async Task UpdateAsync(Basket basket, string url)
        {
            await _service.UpdateAsync(basket, url, _client);
        }
    }
}
