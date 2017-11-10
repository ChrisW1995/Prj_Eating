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
    public class WaitingListController : Controller
    {
        private IWaitingListService waitingListService = new WaitingListService();
        // GET: WaitingList
        public ActionResult Index()
        {         
            return View();
        }

        [HttpGet]
        public JsonResult GetWaitingList()
        {
            var R_Id = Request.Cookies["idCookie"].Values["r_id"];

            var waitList = waitingListService.GetWaitingListsByRAccount(R_Id);
            var join_query = waitingListService.GetJoinCIdWaitingLists(waitList);

            return Json(join_query, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CheckStatus(int Id)
        {
            if (waitingListService.IsExists(Id))
            {
                var instance = waitingListService.GetByID(Id);
                instance.CheckStatus = true;
                waitingListService.Update(instance);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
        }
    }
}