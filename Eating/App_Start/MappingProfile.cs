using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Eating.Models;
using Eating.ViewModels;
using Eating.Areas.Backend.Models;
using Eating.DTOs;

namespace Eating.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer,CustomerRegisterDTO>();
            CreateMap<CustomerRegisterDTO, Customer>();

            CreateMap<Restaurant, RestaurantDetailDTO>();
            CreateMap<RestaurantDetailDTO, Restaurant>();

            CreateMap<Restaurant, RestaurantAccountViewModel>();
            CreateMap<RestaurantAccountViewModel, Restaurant>();

            CreateMap<Restaurant, RestaurantStatusVM>();
            CreateMap<RestaurantStatusVM, Restaurant>();
            
            CreateMap<Restaurant, RestaurantInfoViewModel>();
            CreateMap<RestaurantInfoViewModel, Restaurant>();

            CreateMap<Coupons, CouponListViewModel>();
            CreateMap<CouponListViewModel, Coupons>();

            CreateMap<Seat, SeatViewModel>();
            CreateMap<SeatViewModel, Seat>();

            CreateMap<Seat, NewSeatViewModel>();
            CreateMap<NewSeatViewModel, Seat>();

            CreateMap<WaitingLists, WaitingListViewModel>();
            CreateMap<WaitingListViewModel, WaitingLists>();

            CreateMap<Feedback, FeedbacRatingkViewModel>();
            CreateMap<FeedbacRatingkViewModel, Feedback>();
        }
    }
}