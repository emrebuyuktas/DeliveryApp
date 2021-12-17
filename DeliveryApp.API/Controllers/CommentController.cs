using DeliveryApp.Core.Dtos;
using DeliveryApp.Core.Services.Abstract;
using DeliveryApp.Shared.Result.ComplexTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpPost]
        public async Task<IActionResult> Add(CommentDto commentDto)
        {
            var comment = await _commentService.AddAsync(commentDto);
            if (comment.ResultStatus == ResultStatus.Error)
                return BadRequest(comment);
            return Created(string.Empty,comment);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedComment = await _commentService.DeleteAsync(id);
            if (deletedComment.ResultStatus == ResultStatus.Error)
                return BadRequest(deletedComment);
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> Publish(int id)
        {
            var comment = await _commentService.PublishAsync(id);
            if (comment.ResultStatus == ResultStatus.Error)
                return BadRequest(comment);
            return NoContent();
        }
    }
}
