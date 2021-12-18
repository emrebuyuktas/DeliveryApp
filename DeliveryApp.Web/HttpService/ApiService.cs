using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DeliveryApp.Web.HttpService
{
    public class ApiService<T> : IApiService<T> where T: class
    {
        public async Task<T> GetAsync(string url,HttpClient httpClient)
        {
            var response = await httpClient.GetAsync(url);

            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());


        }

    }
}
