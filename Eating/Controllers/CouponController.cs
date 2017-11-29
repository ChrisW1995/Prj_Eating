using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eating.Models;
using Eating.ViewModels;
using Eating.Service.Interface;
using Eating.Service;
using AutoMapper;
using System.Web.Security;
using Eating.Areas.Backend.Service;

namespace Eating.Controllers
{
    [CustomAuthorization(LoginPage = "/Restaurant/Login", Roles = "User")]
    public class CouponController : Controller
    {
        private ICouponService couponService = new CouponService();

        // GET: Coupon
        public ActionResult Index()
        {
            var R_Id = Request.Cookies["idCookie"].Values["r_id"];

            var query = couponService.GetConponByRAccount(R_Id).Select(Mapper.Map<Coupons, CouponListViewModel>);
            return View(query);
        }
        public ActionResult New()
        {
            ViewBag.CouponTitle = "新增優惠券";
            return View("CouponForm");
        }

        public ActionResult Edit(string id)
        {
            var query = couponService.GetByID(id);
            var couponVM = new CouponListViewModel()
            {
                 CouponId = query.CouponId,
                 Desciption = query.Desciption,
                  StartTime = query.StartTime,
                  EndTime = query.EndTime,
                  Title = query.Title
            };
            ViewBag.CouponTitle = "編輯優惠券";
            return View("CouponForm", couponVM);
        }
        [HttpPost]
        public ActionResult Save(CouponListViewModel couponVM)
        {
            if (!ModelState.IsValid)
            {
                return View("CouponForm", couponVM);
            }

            //New
            if(couponVM.CouponId == null)
            {
                var cookie = Request.Cookies["idCookie"];
                var R_Id = cookie.Values["r_id"];
                Coupons instance = new Coupons
                {

                    CouponId = Guid.NewGuid().ToString("N"),
                    R_Id = R_Id,
                    StartTime = couponVM.StartTime,
                    EndTime = couponVM.EndTime,
                    Title = couponVM.Title,
                    Desciption = couponVM.Desciption
                };
                couponService.Create(instance);
            }
            else
            {
                var coupon = couponService.GetByID(couponVM.CouponId);
                Mapper.Map<CouponListViewModel, Coupons>(couponVM, coupon);
                couponService.Update(coupon);
            }
            
            return RedirectToAction("Index");
        }
    }
}