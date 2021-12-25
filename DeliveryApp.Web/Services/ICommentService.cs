using DeliveryApp.Core.Dtos;
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
        Task<string> AddAsync(CommentDto Comment, string url);
        Task DeleteAsync(string url, string id);
        Task UpdateAsync(CommentUpdate update, string url);
    }
}
