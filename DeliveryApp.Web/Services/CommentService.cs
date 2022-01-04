using DeliveryApp.Core.Dtos;
using DeliveryApp.Web.HttpService;
using DeliveryApp.Web.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Services
{
    public class CommentService:ICommentService
    {
        private readonly HttpClient _client;
        private readonly IApiService<CommentDto> _service;
        private readonly IApiService<Comment> _comments;
        private readonly IApiService<CommentUpdate> _update;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CommentService(HttpClient client, IApiService<CommentDto> service, IApiService<CommentUpdate> update, IHttpContextAccessor httpContextAccessor)
        {

            _client = client;
            _service = service;
            _update = update;
            _httpContextAccessor = httpContextAccessor;
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_httpContextAccessor.HttpContext.Request
.Cookies["DeliveryApp"]);
        }

        public async Task<string> AddAsync(CommentDto Comment, string url)
        {
            return await _service.AddAsync(Comment, url, _client);
        }

        public async Task DeleteAsync(string url, string id)
        {
            await _service.DeleteAsync(url + id, _client);
        }

        public async Task<Comment> GetAsync(string url)
        {
            return await _comments.GetAsync(url, _client);
        }
        
        public async Task UpdateAsync(CommentUpdate update, string url)
        {
            await _update.UpdateAsync(update, url, _client);
        }
    }
}
