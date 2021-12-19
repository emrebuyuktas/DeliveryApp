using AutoMapper;
using DeliveryApp.Core.Dtos;
using DeliveryApp.Core.Entities.Concrete;
using DeliveryApp.Core.Repositories.Abstract;
using DeliveryApp.Core.Services.Abstract;
using DeliveryApp.Core.UnitOfWorks;
using DeliveryApp.Shared.Result.Abstract;
using DeliveryApp.Shared.Result.ComplexTypes;
using DeliveryApp.Shared.Result.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Services.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IBasketRepository _basketRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public OrderService(IBasketRepository basketRepo, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, IMapper mapper)
        {
            _basketRepo = basketRepo;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IDataResult<OrderDto>> CreateOrderAsync(string basketId)
        {
            var basket =await _basketRepo.GetBasketAsync(basketId);
            var productList = new List<Product>();
            foreach (var product in basket.Items)
            {
                productList.Add(await _unitOfWork.Products.GetAsync(x => x.Id == product.Id));
            }
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var deliveryAddress = user.Adresses.Neighbourhood + " " + user.Adresses.Street + " " + " " + user.Adresses.DoorNumber + " " + user.Adresses.City;
            Order order = new Order(productList,deliveryAddress,user.Id,user,basket.TotalPrice);
            await _unitOfWork.Order.AddAsync(order);
            var returnDto=_mapper.Map<OrderDto>(order);
            return new DataResult<OrderDto>(ResultStatus.Succes, returnDto);
        }
    }
}
