﻿using DeliveryApp.Core.Dtos;
using DeliveryApp.Core.Entities.Concrete;
using DeliveryApp.Shared.Result.Abstract;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DeliveryApp.Core.Services.Abstract
{
    public interface IUserService
    {
        Task<IResult> UserRegisterAsync(UserRegisterDto userRegisterDto);
        Task<IDataResult<UserDto>> UserLoginAsync(UserLoginDto userLoginDto);
        Task<IResult> UserUpdateAsync(UserUpdateDto userRegisterDto);
        Task<IResult> UserDeleteAsync(int id);
        Task<IResult> UserPaswordChangeAsync(PasswordChangeDto passwordChangeDto, ClaimsPrincipal user);
        Task<IDataResult<UserListDto>> GetUserAsync(int id);
        Task<IDataResult<IList<UserListDto>>> GetUserListAsync();

    }
}
