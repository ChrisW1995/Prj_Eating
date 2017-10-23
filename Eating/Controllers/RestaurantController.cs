using Eating.Models;
using Eating.Service;
using Eating.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;

namespace Eating.Controllers
{
    public class RestaurantController : Controller
    {
        private MemberService memberService = new MemberService();
        private MailService mailService = new MailService();
        private AddressService addressService = new AddressService();
        private ApplicationDbContext db = new ApplicationDbContext();
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        // GET: Restaurant

        public ActionResult Register()
        {
            
            var model = new RestaurantRegisterViewModel
            {
                Counties = db.Counties
            };
            
            
            return View(model);
        }

        [HttpGet]
        public JsonResult Areas(string county)
        {
            var q = db.Counties.Where(x => x.CountyName == county).Select( x => new { Id = x.Id});
            var list = addressService.GetAllAreas(q.First().Id);
            //產品
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Register(RestaurantRegisterViewModel registerMember)
        {
            //var errors = ModelState.Values.SelectMany(v => v.Errors);
            
            if (ModelState.IsValid)
            {
                var checkAccount = memberService.AccountCheck(registerMember.R_Account);
                if (checkAccount == false)
                {
                    var area = db.Counties.Where(x => x.CountyName == registerMember.R_County).Select(x => new { Id = x.Id });

                    ModelState.AddModelError("R_Account", "該帳號已被註冊，請重新嘗試");
                    var regist = new RestaurantRegisterViewModel
                    {
                        R_Account = null,
                        R_Password = null,
                        checkR_Password = null,
                        Counties = db.Counties,
                        Areas = area == null ? null : addressService.GetAllAreas(area.First().Id)

                    };
                    return View(regist);
                }

                string AuthCode = mailService.GetValidateCode(); //get random code

                Restaurant _newMember = new Restaurant()
                {
                    Id = registerMember.Id,
                    R_Account = registerMember.R_Account,
                    R_Password = registerMember.R_Password,
                    R_PhoneNum = registerMember.R_PhoneNum,
                    R_Name = registerMember.R_Name,
                    Email = registerMember.Email,
                    SignUpTime = DateTime.Now,
                    R_County = registerMember.R_County,
                    R_Area = registerMember.R_Area,
                    R_DetailAddress = registerMember.DetailAddr,
                    AuthCode = AuthCode,
                    StartTime = registerMember.StartTime,
                    CloseTime = registerMember.CloseTime,
                    StatusFlg = false,
                    isCheck = false
                };
               

                memberService.Register(_newMember);

                string TempMail = System.IO.File.ReadAllText( 
                    Server.MapPath("~/Views/Shared/RegisterEmailTemplate.html"));

                UriBuilder ValidateUrl = new UriBuilder(Request.Url)
                {
                    Path = Url.Action("EmailValidate", "Restaurant"
                    , new
                    {
                        UserName = registerMember.Id,
                        AuthCode = AuthCode
                    })
                };
                //Write user data to validate mail sample
                string MailBody = mailService.GetRegisterMailBody(TempMail,
                     registerMember.R_Name,
                     ValidateUrl.ToString().Replace("%3F", "?"));
                mailService.SendRegisterMail(MailBody, registerMember.Email);

                TempData["RegisterState"] = "註冊成功,請到個人信箱驗證Email地址";

                return RedirectToAction("RegisterResult");
            }

            int _id=0;
            if(registerMember.R_County != null)
            {
                 _id = db.Counties.Where(x => x.CountyName == registerMember.R_County).SingleOrDefault().Id;
            }
            //產品
            var registVM = new RestaurantRegisterViewModel
            {
                R_Password = null,
                checkR_Password = null,
                Counties = db.Counties,
                 Areas = (_id == 0? null : addressService.GetAllAreas(_id))

            };
          
            return View(registVM);
            
        }

        public ActionResult RegisterResult()
        {
            return View();
        }

        public JsonResult AccountCheck(RestaurantRegisterViewModel registerMember)
        {
            return Json(memberService.AccountCheck(registerMember.R_Account),
                JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Email Validate
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="AuthCode"></param>
        /// <returns></returns>
        public ActionResult EmailValidate(string UserName, string AuthCode)
        {
            ViewData["EmailValidate"] = memberService.EmailValidate(UserName, AuthCode);
            return View();
        }

        public ActionResult Login()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Login(MemberLoginViewModel LoginVM, string returnUrl)
        {
            string ValidateStr = memberService.LoginCheck(LoginVM.R_Account, LoginVM.R_Password);

            //When ValidateStr is empty string, it'll login successful
            if (string.IsNullOrEmpty(ValidateStr))
            {
                if(!memberService.isCheck(LoginVM.R_Account))
                {
                    ModelState.AddModelError("", "尚未通過真實驗證，請等候通過");
                    return View();
                }
                var r = db.Restaurants.Where(a => a.R_Account == LoginVM.R_Account).SingleOrDefault();
                var r_id = r.Id;
                HttpContext.Session.Clear();
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                    r.R_Name,
                    DateTime.Now,
                    DateTime.Now.AddHours(24),
                    false,
                    "User"
                    );
                
                var idCookie = new HttpCookie("idCookie");
                idCookie.Expires.AddHours(24);
                idCookie.Values.Add("r_id", r_id.ToString());
                //Encrypt cookie
                string enTicket = FormsAuthentication.Encrypt(ticket);
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, enTicket));
                Response.Cookies.Add(idCookie);

                string decodedUrl = "";
                if (!string.IsNullOrEmpty(returnUrl))
                    decodedUrl = Server.UrlDecode(returnUrl);

                //Login logic...

                if (Url.IsLocalUrl(decodedUrl))
                {
                    return Redirect(decodedUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            else //Login failed
            {
                ModelState.AddModelError("", ValidateStr);
                return View(LoginVM);
            }

            
        }

        [Authorize(Roles = "User")]
        public ActionResult Info()
        {
            var restaurant = memberService.GetRestaurant(Request.Cookies["idCookie"].Values["r_id"]);
            var infoVM = new RestaurantInfoViewModel();
            Mapper.Map(restaurant, infoVM);
            return View(infoVM);
        }

        public ActionResult accPartial()
        {
            var restaurant = memberService.GetRestaurant(Request.Cookies["idCookie"].Values["r_id"]);
            var accVM = new RestaurantAccountViewModel();
            Mapper.Map(restaurant, accVM);
            accVM.R_Password = string.Empty;
            return PartialView("_AccountPartial", accVM);
        }

        public ActionResult infoPartial()
        {
            var account = memberService.GetRestaurant(Request.Cookies["idCookie"].Values["r_id"]);
            account.R_Password = null;
            var infoVM = new RestaurantInfoViewModel();
            Mapper.Map(account, infoVM);
            return PartialView("_InfoPartial", infoVM);
        }

        [Authorize(Roles = "User")]
        public ActionResult SaveInfo(RestaurantInfoViewModel _infoVM)
        {
            if (!ModelState.IsValid)
            {
                return View("Info", _infoVM);
            }

            var instance = memberService.GetRestaurant(User.Identity.Name);

            Mapper.Map(_infoVM, instance);
            var result = memberService.Update(instance);

            if (result.Success)
            {
                TempData["Messageinfo"] = "bootbox.alert('修改完成');";
                TempData["infoClassColor"] = "green";

            }
            else
            {
                TempData["Messageinfo"] = "bootbox.alert('Error！請重新確認後再試一次');";
                TempData["infoClassColor"] = "red";
            }
            return RedirectToAction("Info");

        }
        public ActionResult SaveAccount(RestaurantAccountViewModel r_AccountVM)
        {
            var _R_AccountVM = new RestaurantAccountViewModel()
            {
                R_Account = memberService.GetRestaurant(User.Identity.Name).R_Account
            };
            if (!ModelState.IsValid)
            {
                 return View("Info", _R_AccountVM);
            }

            var checkPassword = memberService.LoginCheck(User.Identity.Name, r_AccountVM.R_Password);
            if(!string.IsNullOrWhiteSpace(checkPassword))
            {
                ModelState.AddModelError("R_Password", "舊密碼有誤，請重新再試一次");
                return View("Info", _R_AccountVM);
            }

            var restaurant = memberService.GetRestaurant(User.Identity.Name);
            restaurant.R_Password = memberService.HashPassword(r_AccountVM.new_R_Password);
           var result =  memberService.Update(restaurant);
            if (result.Success)
            {
                TempData["Messageacc"] = "bootbox.alert('密碼已成功儲存，下次請以新密碼登入');";
                TempData["classColor"] = "green";

            }
            else
            {
                TempData["Messageacc"] = "bootbox.alert('儲存失敗');";
                TempData["classColor"] = "red";
            }
            return RedirectToAction("Info");
        }
        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}