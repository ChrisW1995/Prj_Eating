using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eating.Models;
using Eating.Interface;
using Eating.Service;
using Eating.Service.Interface;
using Eating.ViewModels;

namespace Eating.Controllers
{
    public class HomeController : Controller
    {
        private IFeedBackService feedbackService = new FeedbackService();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetRating(string r_id)
        {
           var list = feedbackService.GetRatingVM(r_id);
            var group_list = list.GroupBy(g => g.Rating);
            return Json(group_list, JsonRequestBehavior.AllowGet);
        }

      
    }
}