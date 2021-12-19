﻿using AutoMapper;
using DeliveryApp.Core.Dtos;
using DeliveryApp.Core.Entities.Concrete;

namespace DeliveryApp.Services.AutoMapper.Profiles
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
        }
    }
}