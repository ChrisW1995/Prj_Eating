using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eating.Models;
using Eating.Service;
using Eating.Service.Interface;
using Eating.ViewModels;
using AutoMapper;
using System.Net;
using Eating.Areas.Backend.Service;

namespace Eating.Controllers
{
    [CustomAuthorization(LoginPage = "/Restaurant/Login", Roles = "User")]
    public class ReserveController : Controller
    {
        private IReservationService reserveService = new ReservationService();
        private ISeatService seatService = new SeatService();

        // GET: Reserve
        public ActionResult Index()
        {
            var cookie = Request.Cookies["idCookie"];
            var R_Id = cookie.Values["r_id"];
            var SeatList = seatService.GetSeatByRAccount(R_Id).Select(Mapper.Map<Seat, SeatViewModel>);

            return View(SeatList);

        }

        [HttpPost]
        public ActionResult SaveTimePart(SetReservationTimeViewModel vm)
        {
            var r_id = Request.Cookies["idcookie"].Values["r_id"];
            var instance = Mapper.Map<SetReservationTimeViewModel, SetReservationDetails>(vm);
            var seats = seatService.GetSeatByRAccount(r_id);
            if (seats.Count()==0)
            {
                TempData["Error"] = "bootbox.alert('請先新增座位後再試一次！');";
                return RedirectToAction("Index");
            }
            foreach (var seat in seats)
            {
                instance.SeatId = seat.Id;
                instance.R_id = r_id;
                var result = reserveService.CreateTime(instance);
                if (result.Success == false)
                    ModelState.AddModelError("ReservationTime", "目前發生錯誤，請稍後再試。");

            }
            return RedirectToAction("Index");
        }
        public ActionResult _ReserveSettingList()
        {
            var R_Id = Request.Cookies["idCookie"].Values["r_id"];
           
            return PartialView(reserveService.GetSettingList(R_Id));
        }
        public ActionResult _SetReservePart()
        {
            return PartialView();
        }

        public ActionResult DelSetTime(string r_id, TimeSpan time)
        {
            var times = reserveService.GetSettingList(r_id, time);
            foreach(var _time in times)
            {
                var result = reserveService.DelSetTimes(_time);
                if (result.Success == false)
                {
                    TempData["Error"] = "bootbox.alert('刪除失敗，請稍後再試');";
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult GetReservedSeat(string name, string date)
        {
            var reservedList = reserveService.GetReserveListByRAccount(name, reserveService.GetList().Where(d => d.AddTime.ToString("yyyy/MM/dd") == date));
            if(reservedList.Count()==0 || reservedList == null)
            {
                return HttpNotFound();
            }
            return Json(reservedList, JsonRequestBehavior.AllowGet);
        }
       
        [HttpPost]
        public ActionResult SaveReserve(IEnumerable<ReserveViewModel> reserveVM)
        {
            {
                foreach(var item in reserveVM)
                {
                    try
                    {
                        var instance = reserveService.GetByID(item.Id);
                        instance.Id = item.SeatId;
                        reserveService.Update(instance);
                    }
                    catch(Exception e)
                    {
                        return JavaScript("<script>alert(\"Error\")</script>");
                        throw e;
                    }
                               
                }
                TempData["Time"] = reserveVM.FirstOrDefault().AddTime.ToString("yyyy/MM/dd");
                return RedirectToAction("Index");

            }
            
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}