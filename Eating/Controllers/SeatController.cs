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
using Eating.Areas.Backend.Service;

namespace Eating.Controllers
{
    [CustomAuthorization(LoginPage = "/Restaurant/Login", Roles = "User")]
    public class SeatController : Controller
    {
        private ISeatService seatService = new SeatService();
        private IReservationService reservationService = new ReservationService();
        // GET: Seat
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult Delete(int? id)
        {
            var result = seatService.Delete(id);
            if (result.Success)
            {
                TempData["Error"] = "刪除成功";
            }
            else
            {
                TempData["Error"] = "刪除失敗，請重新再試一次";
            }
            return RedirectToAction("Index");
        }

        public ActionResult GetSeatList()
        {
            var R_Id = Request.Cookies["idCookie"].Values["r_id"];
            var SeatList = seatService.GetSeatByRAccount(R_Id).Select(Mapper.Map<Seat, SeatViewModel>);
            return PartialView("_SeatList", SeatList);
        }

        public ActionResult GetNewSeatPartial()
        {
            return PartialView("_NewSeat");
        }

        public ActionResult GetLocationPartial(SeatViewModel seatVM)
        {
            var R_Id = Request.Cookies["idCookie"].Values["r_id"];

            var SeatList = seatService.GetSeatByRAccount(R_Id).Select(Mapper.Map<Seat, SeatViewModel>);

            return PartialView("_SeatLocation", SeatList);
        }
        [HttpPost]
        public ActionResult Save(NewSeatViewModel SeatVM)
        {
            var R_Id = Request.Cookies["idCookie"].Values["r_id"];

            if (!ModelState.IsValid)
            {
                TempData["seatMessage"] = "bootbox.alert('請輸入桌號！');" ;
                return View("Index", SeatVM);
            }
            //New
            if(SeatVM.Id == 0 || SeatVM.Id == null)
            {
                
                var instance = Mapper.Map<NewSeatViewModel, Seat>(SeatVM);
                instance.R_Id = R_Id;
                var result = seatService.Create(instance);
                var times = reservationService.GetSettingList(R_Id);
                if(times.Count()!= 0)
                {
                    var seatId = instance.Id;
                    foreach(var time in times)
                    {
                        var time_instance = new SetReservationDetails()
                       {
                            R_id = R_Id,
                            ReservationTime = time.ReservationTime,
                            SeatId = seatId
                        };
                        reservationService.CreateTime(time_instance);
                    }
                }
                
                string msg = result.Success == true ?  "" : "bootbox.alert('錯誤，請重新再試一次！');";
                TempData["seatMessage"] = msg;
                return RedirectToAction("Index");
            }
            else
            {
                var SeatInDb = seatService.GetByID(SeatVM.Id);
                Mapper.Map(SeatVM, SeatInDb);
                SeatInDb.R_Id = R_Id;
                var result = seatService.Update(SeatInDb);
                string msg = result.Success == true ? "bootbox.alert('修改成功', function(){ location.replace('/Seat/Index'); });" : "bootbox.alert('錯誤，請重新再試一次！');";
                TempData["seatEditMessage"] = msg;
                return View("Index");
            }
            
        }

        public ActionResult Create()
        {
            return View("SeatForm");
        }

        public ActionResult Edit(int? id)
        {
            var seat = seatService.GetByID(id);
            var seatVM = new NewSeatViewModel();
            return View("SeatForm", Mapper.Map(seat, seatVM));
        }

        public ActionResult Location()
        {
            var R_Id = Request.Cookies["idCookie"].Values["r_id"];

            var seatLst = seatService.GetSeatByRAccount(R_Id).Select(Mapper.Map<Seat, SeatViewModel>);
            return View(seatLst);
        }

        public ActionResult SaveLocation(IEnumerable<SeatViewModel> SeatViewModel)
        {
            foreach(var item in SeatViewModel)
            {
                var seat = seatService.GetByID(item.Id);
                seat.location_X = item.location_X;
                seat.location_Y = item.location_Y;
                var result = seatService.Update(seat);
                if(result.Success == false)
                {
                    TempData["Message"] = "bootbox.alert('儲存失敗! 請重新再試一次');";
                    TempData["color"] = "Red";
                    return RedirectToAction("Location");
                }
            }
            TempData["Message"] = "bootbox.alert('已儲存擺放位置');";
            TempData["color"] = "Green";
            return RedirectToAction("Index");
        }

    }
}