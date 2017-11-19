using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eating.Service
{
    public class LocalDateTimeService
    {
        public LocalDateTimeService()
        {

        }
        public DateTime getLocalDateTime(string location)
        {
            var localTime = DateTime.Now;
            TimeZoneInfo destTz =
            TimeZoneInfo.FindSystemTimeZoneById(location);
            var datetime = TimeZoneInfo.ConvertTime(localTime, TimeZoneInfo.Local, destTz);
            return datetime;
        }
    }
}