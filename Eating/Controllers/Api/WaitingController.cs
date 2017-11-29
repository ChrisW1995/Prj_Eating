using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Eating.Service;
using Eating.DTOs;
using Eating.Models;
using AutoMapper;

namespace Eating.Controllers.Api
{
    public class WaitingController : ApiController
    {
        WaitingListService waitingListService = new WaitingListService();

        // GET: api/Waiting/5
        public IHttpActionResult Get(int id)
        {
            var list = waitingListService.GetWaitingListsByCAccount(id);

            if (list == null)
            {
                return NotFound();
            }

            return Ok(list);
        }

        // POST: api/Waiting
        public IHttpActionResult NewWaiting(NewWaitingDTO customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("請檢查欄位是否有遺漏");
            }
            if(waitingListService.IsWaiting(customer.C_Id, customer.R_Id))
            {
                return BadRequest("您已在候位列表中，請等候通知");
            }
            
            var instance = Mapper.Map<NewWaitingDTO, WaitingLists>(customer);
            var localTime = DateTime.Now;
            TimeZoneInfo destTz =
            TimeZoneInfo.FindSystemTimeZoneById("China Standard Time");
            var addTime = TimeZoneInfo.ConvertTime(localTime, TimeZoneInfo.Local, destTz);
            instance.CheckStatus = false;
            instance.CurrentNo = waitingListService.GetNewCurrentNum(customer.R_Id);
            instance.AddTime = addTime;
            var result = waitingListService.Create(instance);
            if(!result.Success)
                return BadRequest("操作失敗，請重新操作一次");
            return Created(new Uri(Request.RequestUri + "/" + customer.C_Id), instance);

        }

    }
}
