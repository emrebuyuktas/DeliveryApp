using DeliveryApp.Core.Entities.Concrete;
using DeliveryApp.Core.Services.Abstract;
using DeliveryApp.Shared.Result.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public Task<IResult> UserDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UserLoginAsync(UserLoginDto userRegisterDto)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UserPaswordChangeAsync(PaswordChangeDto paswordChangeDto)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UserRegisterAsync(UserRegisterDto userRegisterDto)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UserUpdateAsync(UserUpdateDto userRegisterDto)
        {
            throw new NotImplementedException();
        }
    }
}
