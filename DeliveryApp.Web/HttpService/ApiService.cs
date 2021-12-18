//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using DeliveryApp.Web.Models;

namespace DeliveryApp.Web.HttpService
{
    public class ApiService<T> : IApiService<T> where T: class
    {
        public async Task<T> GetAsync(string url,HttpClient httpClient)
        {
            await Task.Delay(2000);
            var response = await httpClient.GetAsync(url);
            return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync());

        }

    }
}
