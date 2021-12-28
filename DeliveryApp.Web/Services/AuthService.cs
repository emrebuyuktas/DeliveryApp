using DeliveryApp.Core.Dtos;
using DeliveryApp.Web.HttpService;
using DeliveryApp.Web.Models;
using System.Net.Http;
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

        public async Task<string> RegisterAsync(UserRegisterDto userRegisterDto, string url)
        {
            return await _register.AddAsync(userRegisterDto, url, _client);
        }

        public async Task DeleteAsync(string url, string id)
        {
            await _service.DeleteAsync(url + id, _client);
        }

        public async Task<User> GetAsync(string url)
        {
            return await _service.GetAsync(url, _client);
        }
        public async Task<string> LoginAsync(UserLoginDto userLoginDto, string url)
        {
            return await _login.AddAsync(userLoginDto,url, _client);
        }

        public async Task UpdateAsync(UserUpdateDto userUpdateDto, string url)
        {
            await _update.UpdateAsync(userUpdateDto, url, _client);
        }
    }
}
