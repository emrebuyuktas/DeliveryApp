using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DeliveryApp.Web.HttpService
{
    public interface IApiService<T> where T: class
    {
        Task<T> GetAsync(string url, HttpClient client);
    }
}
