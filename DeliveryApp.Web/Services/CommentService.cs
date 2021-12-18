using DeliveryApp.Web.HttpService;
using DeliveryApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Services
{
    public class CommentService:ICommentService
    {
        private readonly HttpClient _client;
        private readonly IApiService<Comment> _service;

        public CommentService(HttpClient client, IApiService<Comment> service)
        {

            _client = client;
            _service = service;
        }

        public async Task<string> AddAsync(Comment Comment, string url)
        {
            return await _service.AddAsync(Comment, url, _client);
        }

        public async Task DeleteAsync(string url, string id)
        {
            await _service.DeleteAsync(url + id, _client);
        }

        public async Task<Comment> GetAsync(string url)
        {
            return await _service.GetAsync(url, _client);
        }
        
        public async Task UpdateAsync(Comment comment, string url)
        {
            await _service.UpdateAsync(comment, url, _client);
        }
    }
}
