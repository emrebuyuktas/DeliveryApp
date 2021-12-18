using AutoMapper;
using DeliveryApp.Web.HttpService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Services
{
    public class ServiceBase<Tin, Tout> : IServicesBase<Tin, Tout> where Tin : class where Tout : class
    {

        private readonly IMapper _mapper;
        private readonly IApiService<Tin> _httpServiceBase;
        private HttpClient _httpClient;
       
        public ServiceBase(IMapper mapper, HttpClient httpClient, IApiService<Tin> httpServiceBase)
        {
            _mapper = mapper;
            _httpClient = httpClient;
            _httpServiceBase = httpServiceBase;
        }



        public async Task<Tout> GetAsync(string url)
        {

            var connectionUrl = url;
            var response = await _httpServiceBase.GetAsync(url, _httpClient);
            var result = _mapper.Map<Tout>(response);

            return result;

        }
    }
}
