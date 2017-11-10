using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Eating.Service;

namespace Eating.Controllers.Api
{
    public class WaitingController : ApiController
    {
        WaitingListService waitingListService = new WaitingListService();

        // GET: api/Waiting/5
        public IHttpActionResult Get(string id)
        {
            var list = waitingListService.GetWaitingListsByRAccount(id);

            if (list == null)
            {
                return NotFound();
            }

            return Ok(list);
        }

        // POST: api/Waiting
        public void Post([FromBody]string value)
        {
        }

    }
}
