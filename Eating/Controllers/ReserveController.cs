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

namespace Eating.Controllers
{
    [Authorize]
    public class ReserveController : Controller
    {
        private IReserveService reserveService = new ReserveService();
        private ISeatService seatService = new SeatService();

        // GET: Reserve
        public ActionResult Index()
        {
            //var list = reserveService.GetReserveListByRAccount(User.Identity.Name, reserveService.GetAll());
            var R_Id = User.Identity.Name;
            var SeatList = seatService.GetSeatByRAccount(R_Id).Select(Mapper.Map<Seat, SeatViewModel>);

            return View(SeatList);

        }

        [HttpGet]
        public ActionResult GetReservedSeat(string name, string date)
        {
            var reservedList = reserveService.GetReserveListByRAccount(name, reserveService.GetAll().Where(d => d.ReserveTime.ToString("yyyy/MM/dd") == date));
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
                        instance.SeatId = item.SeatId;
                        reserveService.Update(instance);
                    }
                    catch(Exception e)
                    {
                        return JavaScript("<script>alert(\"Error\")</script>");
                    }
                               
                }
                TempData["Time"] = reserveVM.FirstOrDefault().ReserveTime.ToString("yyyy/MM/dd");
                return RedirectToAction("Index");

            }
            TempData["Time"] = reserveVM.FirstOrDefault().ReserveTime.ToString("yyyy/MM/dd");
            return RedirectToAction("Index");
        }
    }
}