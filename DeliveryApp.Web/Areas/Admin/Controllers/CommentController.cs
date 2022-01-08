﻿using DeliveryApp.Core.Dtos;
using DeliveryApp.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Areas.Admin.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var comments = await _commentService.GetAsync("https://localhost:44369/api/Comment");
            return View(comments);
        }
        [HttpPost]
        public async Task<IActionResult> PublishComment(CommentPublishDto commentPublishDto)
        {
            await _commentService.UpdateAsync(commentPublishDto, "https://localhost:44369/api/Comment");
            return RedirectToAction("Index", "Category");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteComment(int commentId)
        {
            await _commentService.DeleteAsync($"https://localhost:44369/api/Comment/{commentId}");
            return RedirectToAction("Index", "Category");
        }
    }
}