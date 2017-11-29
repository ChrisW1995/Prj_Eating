using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eating.Service;
using Eating.Areas.Backend.Models;
using Eating.Areas.Backend.Service;
using System.Web.Security;
using System.Net;

namespace Eating.Areas.Backend.Controllers
{
    public class AdminController : Controller
    {
        MemberService memberService = new MemberService();
        AdminService adminService = new AdminService();
        // GET: Backend/Admin

        [CustomAuthorization(LoginPage = "/Backend/Admin/Login", Roles = "Admin")]
        public ActionResult Index(string ddlStatus)
        {
            ViewBag.index = ddlStatus;
            return View();
            
        }

        public ActionResult Login()
        {
            return View();
        }

        [CustomAuthorization(LoginPage = "/Backend/Admin/Login", Roles = "Admin")]
        public ActionResult GetRList(string index)
        {
           
                return PartialView("_GetRList");
            }

        public JsonResult GetList(string index)
        {

            IEnumerable<RestaurantStatusVM> query = null;
            int _index = int.Parse(index);
            switch (_index)
            {
                case 0:
                    query = memberService.GetAllCheckList().ToList().OrderBy(t => t.SignUpTime);
                    break;
                case 1:
                    query = memberService.GetAllCheckList(s => s.StatusFlg == false && s.isCheck == false).OrderBy(t=>t.SignUpTime).ToList();
                    break;
                case 2:
                    query = memberService.GetAllCheckList(s => s.StatusFlg == false && s.isCheck == true).OrderByDescending(t => t.SignUpTime).ToList();
                    break;
                case 3:
                    query = memberService.GetAllCheckList(s => s.StatusFlg == true).OrderByDescending(t => t.SignUpTime).ToList();
                    break;

            }
            return Json(query, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public ActionResult Check(string id, bool flg, int index)
        {
            ViewBag.index = index;
            var query = memberService.GetRestaurant(id);
            query.isCheck = true;
            if (flg)
            {
                query.StatusFlg = true;
            }
            else
            {
                query.StatusFlg = false;
            }
            var result = memberService.Update(query);
            if (result.Success)
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
        }
        [HttpPost]
        public ActionResult Login(AdminLoginVM loginVM, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (adminService.IsExist(loginVM.Adm_Account, loginVM.Adm_Password))
            {
                HttpContext.Session.Clear();
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                    "Admin",
                    DateTime.Now,
                    DateTime.Now.AddHours(24),
                    false,
                    "Admin"
                    );
                //Encrypt cookie
                string enTicket = FormsAuthentication.Encrypt(ticket);
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, enTicket));

                string decodedUrl = "";
                if (!string.IsNullOrEmpty(returnUrl))
                    decodedUrl = Server.UrlDecode(returnUrl);

                return RedirectToAction("index");
            }
            else
            {
                ModelState.AddModelError("", "帳號或密碼錯誤");
                return View(loginVM);
            }
            
            
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}