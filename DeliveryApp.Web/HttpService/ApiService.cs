//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using DeliveryApp.Web.Models;
using System.Text.Json.Serialization;

namespace DeliveryApp.Web.HttpService
{
    public class ApiService<T> : IApiService<T> where T: class
    {
        public async Task<string> AddAsync(T model,string url, HttpClient httpClient)
        {
            StringContent queryString = new StringContent(JsonSerializer.Serialize(model));
            var reponse = await httpClient.PostAsync(url, queryString);
            return await reponse.Content.ReadAsStringAsync();
        }

        public async Task DeleteAsync(string url, HttpClient httpClient)
        {
            await httpClient.DeleteAsync(url);
        }

        public async Task<T> GetAsync(string url,HttpClient httpClient)
        {
            await Task.Delay(2000);
            var response = await httpClient.GetAsync(url);
            return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
        }

        public async Task UpdateAsync(T model, string url, HttpClient httpClient)
        {
            StringContent queryString = new StringContent(JsonSerializer.Serialize(model));
            await httpClient.PutAsync(url,queryString);
        }
    }
}
