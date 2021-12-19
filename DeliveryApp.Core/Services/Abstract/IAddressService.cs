using DeliveryApp.Core.Dtos;
using DeliveryApp.Shared.Result.Abstract;
using System.Threading.Tasks;

namespace DeliveryApp.Core.Services.Abstract
{
    public interface IAddressService
    {
        Task<IDataResult<AddressDto>> GetAsync(int id);
        Task<IDataResult<AddressDto>> GetWithUserIdAsync(int userId);
        Task<IResult> AddAsync(AddressDto address, string userEmail);
        Task<IResult> DeleteAsync(int id);
        Task<IResult> UpdateAsync(AddressDto address);
    }
}
