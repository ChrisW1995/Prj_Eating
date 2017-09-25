using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eating.Models;
using Eating.Interface;
using Eating.Service.Interface;
using Eating.Repository;

namespace Eating.Service
{
    public class SeatService : ISeatService
    {
        private IRepository<Seat> repository = new GenericRepository<Seat>(new ApplicationDbContext());

        public IResult Create(Seat instance)
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

        public IResult Delete(int? SeatID)
        {
            IResult result = new Result(false);

            if (!this.IsExists(SeatID))
            {
                result.Message = "找不到資料";
            }

            try
            {
                var instance = this.GetByID(SeatID);
                this.repository.Delete(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public IEnumerable<Seat> GetAll()
        {
            return repository.GetAll();
        }

        public Seat GetByID(int? SeatID)
        {
            return this.repository.Get(x => x.SeatId == SeatID);
        }

        public IEnumerable<Seat> GetSeatByRAccount(string r_Account)
        {
            return repository.GetAllById(x => x.R_Id == r_Account).ToList();
        }

        public bool IsExists(int? SeatID)
        {
            return this.repository.GetAll().Any(x => x.SeatId == SeatID);
        }

        public IResult Update(Seat instance)
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