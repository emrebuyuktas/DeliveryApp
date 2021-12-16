using DeliveryApp.Core.Dtos;
using DeliveryApp.Shared.Result.Abstract;
using System.Threading.Tasks;

namespace DeliveryApp.Core.Services.Abstract
{
    public interface ICommentService
    {
        Task<IResult> PublishAsync(int id);
        Task<IResult> AddAsync(CommentDto commentDto);
        Task<IResult> DeleteAsync(int id);
    }
}
