using AutoMapper;
using DeliveryApp.Core.Dtos;
using DeliveryApp.Core.Entities.Concrete;
using DeliveryApp.Core.Services.Abstract;
using DeliveryApp.Core.UnitOfWorks;
using DeliveryApp.Shared.Result.Abstract;
using DeliveryApp.Shared.Result.ComplexTypes;
using DeliveryApp.Shared.Result.Concrete;
using System.Threading.Tasks;

namespace DeliveryApp.Services.Concrete
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<IResult> AddAsync(CommentDto commentDto)
        {
            await _unitOfWork.Comment.AddAsync(_mapper.Map<Comment>(commentDto));
            await _unitOfWork.CommitAsync();
            return new Result(ResultStatus.Succes, $"Comment has been added successfully,will be published after checking");
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            var comment=await _unitOfWork.Comment.GetAsync(x=>x.Id==id);
            if (comment == null)
                return new Result(ResultStatus.Error, $"No comment found with specified criteria");
            await _unitOfWork.Comment.DeleteAsync(comment);
            await _unitOfWork.CommitAsync();
            return new Result(ResultStatus.Succes, $"Comment has been deleted successfully");
        }

        public async Task<IResult> PublishAsync(int id)
        {
            var comment = await _unitOfWork.Comment.GetAsync(x => x.Id == id);
            if(comment==null)
                return new Result(ResultStatus.Error, $"No comment found with specified criteria");
            comment.IsPublished = true;
            await _unitOfWork.Comment.UpdateAsync(comment);
            await _unitOfWork.CommitAsync();
            return new Result(ResultStatus.Succes, $"Comment has been published successfully");
        }
    }
}
