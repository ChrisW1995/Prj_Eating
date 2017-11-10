using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eating.Models;
using Eating.Service.Interface;
using Eating.Interface;
using Eating.Repository;
using Eating.ViewModels;

namespace Eating.Service
{
    public class WaitingListService : IWaitingListService
    {
        private IRepository<WaitingLists> repository = new GenericRepository<WaitingLists>(new ApplicationDbContext());
        private ApplicationDbContext db = new ApplicationDbContext();
       
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

        public IResult Delete(int waitingID)
        {
            IResult result = new Result(false);

            if (!this.IsExists(waitingID))
            {
                result.Message = "找不到資料";
            }

            try
            {
                var instance = this.GetByID(waitingID);
                this.repository.Delete(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public IEnumerable<WaitingLists> GetAll()
        {
            return repository.GetAll();
        }

        public WaitingLists GetByID(int waitingID)
        {
            return this.repository.Get(x => x.Id == waitingID);
        }

        public IEnumerable<WaitingLists> GetWaitingListsByRAccount(string r_id)
        {
            return repository.GetAllById(x => x.R_Id == r_id).Where(s => s.CheckStatus == false).OrderBy(x => x.CurrentNo).ToList();
        }

        public IEnumerable<WaitingLists> GetWaitingListsByCAccount(int c_Account)
        {
            return repository.GetAllById(x => x.C_Id == c_Account).ToList();
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

        public bool IsExists(int waitingID)
        {
            return this.repository.GetAll().Any(x => x.Id == waitingID);
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