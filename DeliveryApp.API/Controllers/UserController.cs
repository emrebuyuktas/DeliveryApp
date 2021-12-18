using DeliveryApp.Core.Dtos;
using DeliveryApp.Core.Entities.Concrete;
using DeliveryApp.Core.Services.Abstract;
using DeliveryApp.Shared.Result.ComplexTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DeliveryApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> User(int id)
        {
            var user = await _userService.GetUserAsync(id);
            return Ok(user);
        }
        [HttpGet]
        public async Task<IActionResult> User()
        {
            var user = await _userService.GetUserListAsync();
            if (user.ResultStatus == ResultStatus.Succes)
                return Ok(user);
            return BadRequest(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var response = await _userService.UserDeleteAsync(id);
            if (response.ResultStatus == ResultStatus.Succes)
                return NoContent();
            return NotFound(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
        {
            var response = await _userService.UserUpdateAsync(userUpdateDto);
            if (response.ResultStatus == ResultStatus.Succes)
                return NoContent();
            return BadRequest(response);
        }
        [HttpPost]
        public async Task<IActionResult> Update(PasswordChangeDto passwordChangeDto)
        {
            var response = await _userService.UserPaswordChangeAsync(passwordChangeDto, HttpContext.User);
            if (response.ResultStatus==ResultStatus.Succes)
            {
                return NoContent();
            }
            return BadRequest(response);
        }
    }
}
