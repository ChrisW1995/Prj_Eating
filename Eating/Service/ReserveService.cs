using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eating.Models;
using Eating.ViewModels;
using Eating.Interface;
using Eating.Service.Interface;
using Eating.Service;
using Eating.Repository;

namespace Eating.Service
{
    public class ReserveService : IReserveService
    {

        private IRepository<Reserves> repository = new GenericRepository<Reserves>(new ApplicationDbContext());
        private ISeatService seatService = new SeatService();
        private ApplicationDbContext db = new ApplicationDbContext();

        public IResult Create(Reserves instance)
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

        public IResult Delete(int reserveID)
        {
            IResult result = new Result(false);

            if (!this.IsExists(reserveID))
            {
                result.Message = "找不到資料";
            }

            try
            {
                var instance = this.GetByID(reserveID);
                this.repository.Delete(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public IEnumerable<Reserves> GetAll()
        {
            return repository.GetAll();
        }

        public Reserves GetByID(int reserveID)
        {
            return this.repository.Get(x => x.Id == reserveID);
        }

        public IEnumerable<ReserveViewModel> GetReserveListByRAccount(string r_id, IEnumerable<Reserves> Reserves)
        { 
            var seatList = seatService.GetSeatByRAccount(r_id);
            var query = from reserve in Reserves
                        join seat in seatList on reserve.SeatId equals seat.SeatId
                        join customer in db.Customers on reserve.C_Id equals customer.C_Id orderby seat.SeatName
                        select new ReserveViewModel
                        {
                             Id = reserve.Id,
                             C_Name = customer.C_Name,
                             C_PhoneNum = customer.C_PhoneNum,
                             Details = reserve.Details,
                             PeopleNum = reserve.PeopleNum,
                             ReserveTime = reserve.ReserveTime,
                             R_Id = seat.R_Id,
                             SeatCapacity = seat.SeatCapacity,
                             SeatId = seat.SeatId,
                             SeatName = seat.SeatName,
                             SeatSmoke = seat.SeatSmoke,
                             Seats = seatList
                        };
            //var q = Reserves.Join(seatList,
            //    r => r.SeatId,
            //    s => s.SeatId,
            //    (r, s) => new ReserveViewModel
            //    {
            //        Id = r.Id,
            //        Details = r.Details,
            //        PeopleNum = r.PeopleNum,
            //        ReserveTime = r.ReserveTime,
            //        R_Id = s.R_Id,
            //        SeatCapacity = s.SeatCapacity,
            //        SeatId = s.SeatId,
            //        SeatName = s.SeatName,
            //        SeatSmoke = s.SeatSmoke,
            //        Seats = seatList
            //    }).OrderBy(i => i.SeatName).ToList();
            return query;
        }

        public ReserveViewModel GetReserveById(int id, string r_Account)
        {
            //    var reserve = repository.Get(i => i.Id == id);
            //    var seatList = seatService.GetSeatByRAccount(r_Account);
            //    var q = Reserves.Join(seatList,
            //        r => r.SeatId,
            //        s => s.SeatId,
            //        (r, s) => new ReserveViewModel
            //        {
            //            Id = r.Id,
            //            C_Id = r.C_Id,
            //            Details = r.Details,
            //            PeopleNum = r.PeopleNum,
            //            ReserveTime = r.ReserveTime,
            //            R_Id = s.R_Id,
            //            SeatCapacity = s.SeatCapacity,
            //            SeatId = s.SeatId,
            //            SeatName = s.SeatName,
            //            SeatSmoke = s.SeatSmoke,
            //            Seats = seatList
            //        }).OrderBy(i => i.SeatName).ToList();
            //    return q;
            return null;
        }

        public bool IsExists(int reserveID)
        {
            return this.repository.GetAll().Any(x => x.Id == reserveID);
        }

        public IResult Update(Reserves instance)
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