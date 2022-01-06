﻿using DeliveryApp.Core.Dtos;
using DeliveryApp.Web.Models;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Services
{
    public interface IProductService
    {
        Task<ProductList> GetAllAsync(string url);
        Task<Product> GetAsync(string url);
        Task<string> AddAsync(ProductList product, string url);
        Task DeleteAsync(string url, string id);
        Task UpdateAsync(ProductUpdateDto productUpdateDto, string url);
        Task UpdateRating(Rating rating, string url);
    }
}
