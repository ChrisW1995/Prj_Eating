using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eating.Models;
using Eating.Service.Interface;
using Eating.Interface;
using Eating.Repository;
using Eating.ViewModels;
using System.Data.Entity;
using FCM.Net;
using System.Configuration;
using System.Threading.Tasks;
using System.Net;
using System.Web.Script.Serialization;
using System.Text;
using System.IO;

namespace Eating.Service
{
    public class WaitingListService : IWaitingListService
    {
        private IRepository<WaitingLists> repository = new GenericRepository<WaitingLists>(new ApplicationDbContext());
        private ApplicationDbContext db = new ApplicationDbContext();
        private LocalDateTimeService localDateTimeService = new LocalDateTimeService();

        public bool IsWaiting(int c_id, string r_id)
        {
            var date = localDateTimeService.GetLocalDateTime("China Standard Time").Date;
            var q = repository.Get(x => x.C_Id == c_id && x.R_Id == r_id && DbFunctions.TruncateTime(x.AddTime) == date && x.CheckStatus == false);
            return q != null ? true : false; 
        }
        public IResult Create(WaitingLists instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException();
            }

            IResult result = new Result(false);

            try
            {
                repository.Create(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public IResult CancelWaiting(int waitingId)
        {
            IResult result = new Result(false);

            try
            {
                var instance = GetByID(waitingId);
                this.repository.Delete(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public IEnumerable<WaitingLists> GetList()
        {
            return repository.GetList();
        }

        public WaitingLists GetByID(int waitingID)
        {
            return this.repository.Get(x => x.Id == waitingID);
        }

        public IEnumerable<WaitingLists> GetWaitingListsByRAccount(string r_id)
        {
            return repository.GetList(x => x.R_Id == r_id).Where(s => s.CheckStatus == false).OrderBy(x => x.CurrentNo).ToList();
        }

        public IEnumerable<WaitingLists> GetWaitingListsByCAccount(int c_Account)
        {
            return repository.GetList(x => x.C_Id == c_Account).ToList();
        }

        public IEnumerable<WaitingListViewModel> GetJoinCIdWaitingLists(IEnumerable<WaitingLists> WaitingLists)
        {
            var q = WaitingLists.Join(db.Customers,
                wl => wl.C_Id,
                c => c.C_Id,
                (wl, c) => new WaitingListViewModel{
                    Id = wl.Id,
                    Detail = wl.Detail,
                    CurrentNo = wl.CurrentNo,
                     AddTime = wl.AddTime,
                     C_Id = c.C_Id,
                     C_Name = c.C_Name
                }).OrderBy(i => i.CurrentNo).ToList();
               
            return q;
        }

        public void SendNotificationAsync(string r_id)
        {
            try
            {
                var q = repository.GetList(r => r.R_Id == r_id).OrderByDescending(r => r.CurrentNo).ToList();
                var regId = "";
                var isCallRedId = q.FirstOrDefault().RegDeviceID;
                if (q.Count() >= 3)
                {
                    regId = q[3].RegDeviceID;
                }

                var applicationID = ConfigurationManager.AppSettings["fcmApiKey"];
                var senderId = ConfigurationManager.AppSettings["fcmSenderId"];
                string deviceId = isCallRedId;
                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                var data = new
                {
                    to = deviceId,
                    notification = new
                    {
                        body = "候位號碼已經輪到你囉! 請至餐廳現場確認座位",
                        title = "有食候",
                        icon = "myicon"
                    },
                    priority = "high"

                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(data);
                Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
                tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                tRequest.ContentLength = byteArray.Length;

                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);

                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                
                            }
                        }
                    }
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            
            
        }
        public int GetNewCurrentNum(string r_id)
        {
            var date = localDateTimeService.GetLocalDateTime("China Standard Time").Date;
            var q = repository.GetList(x => x.R_Id == r_id && DbFunctions.TruncateTime(x.AddTime) == date).OrderByDescending(i => i.CurrentNo).FirstOrDefault();
            return q == null ? 1 : q.CurrentNo+1;
        }
        public bool IsExists(int waitingID)
        {
            return this.repository.GetList().Any(x => x.Id == waitingID);
        }

        public IResult Update(WaitingLists instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException();
            }
            IResult result = new Result(false);
            try
            {
                repository.Update(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }
    }
}