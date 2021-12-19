using DeliveryApp.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Controllers
{
    public class AuthController : Controller
    {

        private readonly IAuthService _auth;
        public AuthController(IAuthService auth)
        {

            _auth = auth;

        }

        /* [HttpPost]
         public async Task<IActionResult> Login(UserLoginDto userLoginDto)
         {
             var response = await _userService.UserLoginAsync(userLoginDto);
             if (response.ResultStatus == ResultStatus.Error)
                 return Unauthorized(response.Message);
             return Ok(response);
         }
         [HttpPost] 
         public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
         {
             var response = await _userService.UserRegisterAsync(userRegisterDto);
             if (response.ResultStatus == ResultStatus.Succes)
             {
                 return Created(string.Empty, response);
             }
             return BadRequest(response);
         }*/
    }

}
