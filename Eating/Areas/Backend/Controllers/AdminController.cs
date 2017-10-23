using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eating.Service;
using Eating.Areas.Backend.Models;
using Eating.Areas.Backend.Service;
using System.Web.Security;

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
        public ActionResult getRList(int index)
        {
            ViewBag.index = index;
            if (string.IsNullOrEmpty(index.ToString()))
            {
                var q = memberService.GetAllCheckList().ToList();
                return View(q);
            }
            else
            {
                IEnumerable<RestaurantStatusVM> query = null;

                switch (index)
                {
                    case 0:
                        query = memberService.GetAllCheckList().ToList();
                        break;
                    case 1:
                        query = memberService.GetAllCheckList(s => s.StatusFlg == false && s.isCheck == false).ToList();
                        break;
                    case 2:
                        query = memberService.GetAllCheckList(s => s.StatusFlg == false && s.isCheck == true).ToList();
                        break;
                    case 3:
                        query = memberService.GetAllCheckList(s => s.StatusFlg == true).ToList();
                        break;

                }
                return PartialView("_GetRList", query);
            }
          
        }

        public ActionResult Check(string id, bool flg)
        {
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
            memberService.Update(query);
            return RedirectToAction("Index");
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