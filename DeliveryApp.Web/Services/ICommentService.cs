using DeliveryApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Services
{
    public interface ICommentService
    {
        Task<Comment> GetAsync(string url);
        Task<string> AddAsync(Comment comment, string url);
        Task DeleteAsync(string url, string id);
        Task UpdateAsync(Comment comment, string url);
    }
}
