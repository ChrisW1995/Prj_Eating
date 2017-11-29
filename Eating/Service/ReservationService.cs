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
using AutoMapper;
using Eating.DTOs;
using System.Data.Entity;

namespace Eating.Service
{
    public class ReservationService : IReservationService
    {

        private IRepository<Reservations> repository = new GenericRepository<Reservations>(new ApplicationDbContext());
        private IRepository<Seat> seatRep = new GenericRepository<Seat>(new ApplicationDbContext());
        private IRepository<SetReservationDetails> setReservartionRep = new GenericRepository<SetReservationDetails>(new ApplicationDbContext());
        private ISetTimeRepository<SetReservationDetails> delSetTimeRep = new SetTimeRepository<SetReservationDetails>(new ApplicationDbContext());
        private ISeatService seatService = new SeatService();
        private ApplicationDbContext db = new ApplicationDbContext();

        public SetReservationDetails GetSetTime(int id)
        {
            return setReservartionRep.Get(i => i.Id==id);
        }

        public IResult DelSetTimes(SetReservationDetails instance)
        {
            if (instance == null) throw new ArgumentNullException();
            bool oldValidateOnSaveEnabled = db.Configuration.ValidateOnSaveEnabled;
            IResult result = new Result(false);
            try
            {
                db.SetReservationDetails.Attach(instance);
                setReservartionRep.Delete(instance);
                result.Success = true;
            }
            catch(Exception e)
            {
                result.Exception = e;
            }
            finally
            {
                db.Configuration.ValidateOnSaveEnabled = oldValidateOnSaveEnabled;
            }
            return result;
        }
        public IEnumerable<SetReservationTimeViewModel> GetSettingList(string r_id)
        {
            var times = setReservartionRep.GetList(r => r.R_id == r_id).GroupBy(t => t.ReservationTime).ToList();
            
            return times.Select( t => new SetReservationTimeViewModel { r_id = r_id, ReservationTime = t.Key }).OrderBy(x =>x.ReservationTime).ToList();
        }
        public IEnumerable<SetReservationDetails> GetSettingList(string r_id, TimeSpan time)
        {
            var times = setReservartionRep.GetList(r => r.R_id == r_id && r.ReservationTime == time).ToList();

            return times;
        }
        public IResult CreateTime(SetReservationDetails instance)
        {
            if (instance == null) throw new ArgumentNullException();
            IResult result = new Result(false);
            try
            {
                setReservartionRep.Create(instance);
                result.Success = true;
            }
            catch(Exception e)
            {
                result.Exception = e;
            }
            return result;
        }
        public IResult Create(Reservations instance)
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

        public IEnumerable<Reservations> GetList()
        {
            return repository.GetList();
        }

        public Reservations GetByID(int reserveID)
        {
            return this.repository.Get(x => x.Id == reserveID);
        }

        public IEnumerable<ReserveViewModel> GetReserveListByRAccount(string r_id, IEnumerable<Reservations> Reserves)
        { 
            var seatList = seatService.GetSeatByRAccount(r_id);
            var query = from reserve in Reserves
                        join seat in seatList on reserve.Id equals seat.Id
                        join customer in db.Customers on reserve.C_Id equals customer.C_Id orderby seat.SeatName
                        select new ReserveViewModel
                        {
                             Id = reserve.Id,
                             C_Name = customer.C_Name,
                             C_PhoneNum = customer.C_PhoneNum,
                             Details = reserve.Details,
                             PeopleNum = reserve.PeopleNum,
                            AddTime = reserve.AddTime,
                             R_Id = seat.R_Id,
                             SeatCapacity = seat.SeatCapacity,
                             SeatId = seat.Id,
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
            return null;
        }

        public bool IsExists(int reserveID)
        {
            return this.repository.GetList().Any(x => x.Id == reserveID);
        }

        public IResult Update(Reservations instance)
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

        public IEnumerable<ReservationTimeDTO> GetReservationTime(DateTime date, int peopleNum, bool isSomke, string r_id)
        {
            var seats = seatRep.GetList(s => s.SeatSmoke == isSomke && s.SeatCapacity >= peopleNum && s.R_Id == r_id).ToList();
        
            if (seats == null) return null;

             
            return null;
           
        }
        
    }
}