﻿using DeliveryApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Services
{
    public interface IBrandService
    {
        Task<Brand> GetAsync(string url);
        Task<string> AddAsync(Brand brand, string url);
        Task DeleteAsync(string url, string id);
        Task UpdateAsync(Brand brand, string url);
    }
}