﻿using DeliveryApp.Core.Dtos;
using DeliveryApp.Web.HttpService;
using DeliveryApp.Web.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Services
{
    public class AuthService : IAuthService
    {

        private readonly HttpClient _client;
        private readonly IApiService<User> _service;
        private readonly IApiService<UserUpdateDto> _update;
        private readonly IApiService<UserRegisterDto> _register;
        private readonly IApiService<UserLoginDto> _login;
        

        public AuthService(IApiService<User> service, HttpClient client, IApiService<UserRegisterDto> register, IApiService<UserLoginDto> login)
        {

            _service = service;
            _client = client;
            _register = register;
            _login = login;
        }

        public async Task<User> RegisterAsync(UserRegisterDto userRegisterDto, string url)
        {
            return JsonSerializer.Deserialize<User>(await _register.AddAsync(userRegisterDto, url, _client), new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
        }

        public async Task DeleteAsync(string url, string id)
        {
            await _service.DeleteAsync(url + id, _client);
        }

        public async Task<User> GetAsync(string url)
        {
            return await _service.GetAsync(url, _client);
        }
        public async Task<User> GetCurrentUserAsync(string url,string token)
        {
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
           // _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
            return await _service.GetAsync(url, _client);
        }
        public async Task<User> LoginAsync(UserLoginDto userLoginDto, string url)
        {

           var response = await _login.AddAsync(userLoginDto, url, _client);
            return JsonSerializer.Deserialize<User>(response, new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
        }

        public async Task UpdateAsync(UserUpdateDto userUpdateDto, string url)
        {
            await _update.UpdateAsync(userUpdateDto, url, _client);
        }
    }
}
