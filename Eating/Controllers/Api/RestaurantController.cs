using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Eating.Service;
using Eating.Models;
using Eating.ViewModels;

namespace Eating.Controllers.Api
{
    public class RestaurantController : ApiController
    {
        MemberService memberService = new MemberService();
        [HttpGet]
        public IHttpActionResult GetList()
        {
            var q = memberService.GetAllList();
            if (q == null)
                return NotFound();

            return Ok(q);
        }
    }
}
