using AutoMapper;
using DeliveryApp.Core.Dtos;
using DeliveryApp.Core.Entities.Concrete;
using DeliveryApp.Core.Repositories.Abstract;
using DeliveryApp.Core.Services.Abstract;
using DeliveryApp.Core.UnitOfWorks;
using DeliveryApp.Data.UnitOfWork;
using DeliveryApp.Shared.Result.Abstract;
using DeliveryApp.Shared.Result.ComplexTypes;
using DeliveryApp.Shared.Result.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliveryApp.Services.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IBasketRepository _basketRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IAddressService _addressService;
        public OrderService(IBasketRepository basketRepo, IUnitOfWork unitOfWork, UserManager<User> userManager, IMapper mapper, IAddressService addressService)
        {
            _basketRepo = basketRepo;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
            _addressService = addressService;
        }


        public async Task<IDataResult<OrderDto>> CreateOrderAsync(string basketId,string userEmail)
        {
            var basket =await _basketRepo.GetBasketAsync(basketId);
            var productList = new List<Product>();
            foreach (var product in basket.Items)
            {
                productList.Add(await _unitOfWork.Products.GetAsync(x => x.Id == product.Id));
            }
            var user = await _userManager.FindByEmailAsync(userEmail);
            var address = await _addressService.GetWithUserIdAsync(user.Id);
            var deliveryAddress = address.Data.Neighbourhood + " " + address.Data.Street + " " + " " + address.Data.DoorNumber + " " + address.Data.City;
            Order order = new Order(productList,deliveryAddress,user.Id,user,basket.TotalPrice);
            await _unitOfWork.Order.AddAsync(order);
            var returnDto=_mapper.Map<OrderDto>(order);
            try
            {
                await _unitOfWork.CommitAsync();
            }
            catch (Exception e)
            {

                throw;
            }
            return new DataResult<OrderDto>(ResultStatus.Succes, returnDto);
        }
    }
}
