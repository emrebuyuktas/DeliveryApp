using DeliveryApp.Shared.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Core.Services.Abstract
{
    public interface IUserService
    {
        Task<IResult> UserRegisterAsync(UserRegisterDto userRegisterDto);
        Task<IResult> UserLoginAsync(UserLoginDto userRegisterDto);
        Task<IResult> UserUpdateAsync(UserUpdateDto userRegisterDto);
        Task<IResult> UserDeleteAsync(int id);
        Task<IResult> UserPaswordChangeAsync(PaswordChangeDto paswordChangeDto);

    }
}
