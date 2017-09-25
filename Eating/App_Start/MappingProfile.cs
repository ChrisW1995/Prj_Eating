using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Eating.Models;
using Eating.ViewModels;

namespace Eating.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Restaurant, RestaurantAccountViewModel>();
            CreateMap<RestaurantAccountViewModel, Restaurant>();

            CreateMap<Restaurant, RestaurantInfoViewModel>();
            CreateMap<RestaurantInfoViewModel, Restaurant>();

            CreateMap<Coupons, CouponListViewModel>();
            CreateMap<CouponListViewModel, Coupons>();

            CreateMap<Seat, SeatViewModel>();
            CreateMap<SeatViewModel, Seat>();

            CreateMap<WaitingLists, WaitingListViewModel>();
            CreateMap<WaitingListViewModel, WaitingLists>();

            CreateMap<Feedback, FeedbacRatingkViewModel>();
            CreateMap<FeedbacRatingkViewModel, Feedback>();
        }
    }
}