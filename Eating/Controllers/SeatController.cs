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

namespace Eating.Controllers
{
    [Authorize]
    public class SeatController : Controller
    {
        private ISeatService seatService = new SeatService();
        // GET: Seat
        public ActionResult Index()
        {
            var R_Id = User.Identity.Name;
            var SeatList = seatService.GetSeatByRAccount(R_Id).Select(Mapper.Map<Seat, SeatViewModel>);
            
            return View(SeatList);
        }

        public ActionResult Delete(int? id)
        {
            var result = seatService.Delete(id);
            if (result.Success)
            {
                ViewBag.JS = "刪除成功";
            }
            else
            {
                ViewBag.JS = "刪除失敗，請重新再試一次";
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Save(SeatViewModel SeatVM)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            //New
            if(SeatVM.SeatId == 0 || SeatVM.SeatId == null)
            {
                var instance = Mapper.Map<SeatViewModel, Seat>(SeatVM);
                instance.R_Id = User.Identity.Name.ToString();
                seatService.Create(instance);
            }
            else
            {
                var SeatInDb = seatService.GetByID(SeatVM.SeatId);
                Mapper.Map<SeatViewModel, Seat>(SeatVM, SeatInDb);
                SeatInDb.R_Id = User.Identity.Name.ToString();
                seatService.Update(SeatInDb);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View("SeatForm");
        }

        public ActionResult Edit(int? id)
        {
            var seat = seatService.GetByID(id);
            var seatVM = new SeatViewModel();
            return View("SeatForm", Mapper.Map(seat, seatVM));
        }

        public ActionResult Location()
        {
            var seatLst = seatService.GetSeatByRAccount(User.Identity.Name).Select(Mapper.Map<Seat, SeatViewModel>);
            return View(seatLst);
        }

        public ActionResult SaveLocation(IEnumerable<SeatViewModel> SeatViewModel)
        {
            foreach(var item in SeatViewModel)
            {
                var seat = seatService.GetByID(item.SeatId);
                seat.location_X = item.location_X;
                seat.location_Y = item.location_Y;
                var result = seatService.Update(seat);
                if(result.Success == false)
                {
                    TempData["Message"] = "儲存失敗! 請重新再試一次";
                    TempData["color"] = "Red";
                    return RedirectToAction("Location");
                }
            }
            TempData["Message"] = "已儲存擺放位置";
            TempData["color"] = "Green";
            return RedirectToAction("Index");
        }

    }
}