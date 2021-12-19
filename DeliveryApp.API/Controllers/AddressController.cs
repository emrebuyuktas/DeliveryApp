using DeliveryApp.Core.Dtos;
using DeliveryApp.Core.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DeliveryApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly IHttpContextAccessor _contextAccessor;

        public AddressController(IAddressService addressService, IHttpContextAccessor contextAccessor)
        {
            _addressService = addressService;
            _contextAccessor = contextAccessor;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Adress(int id)
        {
            var brand = await _addressService.GetAsync(id);
            return Ok(brand);
        }
        [HttpPost]
        public async Task<IActionResult> Adress(AddressDto addressDto)
        {
            var userEmail = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
            return Created(string.Empty,await _addressService.AddAsync(addressDto, userEmail));
        }
    }
}
