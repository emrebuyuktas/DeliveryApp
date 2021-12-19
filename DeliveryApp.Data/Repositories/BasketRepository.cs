﻿using DeliveryApp.Core.Entities.Concrete;
using DeliveryApp.Core.Repositories.Abstract;
using StackExchange.Redis;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace DeliveryApp.Data.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _database;
        public BasketRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public async Task<bool> DeleteBasketAsync(string id)
        {
            return await _database.KeyDeleteAsync(id);
        }

        public async Task<CustomerBasket> GetBasketAsync(string id)
        {
            var data = await _database.StringGetAsync(id);
            CustomerBasket basket = new CustomerBasket();
            if (!data.IsNullOrEmpty)
            {
                basket= JsonSerializer.Deserialize<CustomerBasket>(data);
                foreach (var item in basket.Items)
                {
                    if(item.Quantity>0)
                        basket.TotalPrice += item.Price * item.Quantity;
                    else
                    {
                        basket.TotalPrice += item.Price;
                    }
                }
            }

            return data.IsNullOrEmpty ? null : basket;
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            var created = await _database.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket),
               TimeSpan.FromDays(30));

            if (!created) return null;

            return await GetBasketAsync(basket.Id);
        }
    }
}
