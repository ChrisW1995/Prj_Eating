using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eating.Models;
using Eating.Service.Interface;
using Eating.Interface;
using Eating.Repository;

namespace Eating.Service
{
    public class CouponService : ICouponService
    {
        private IRepository<Coupons> repository = new GenericRepository<Coupons>(new ApplicationDbContext());
        public IResult Create(Coupons instance)
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
            catch(Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public IResult Update(Coupons instance)
        {
            if(instance == null)
            {
                throw new ArgumentNullException();
            }
            IResult result = new Result(false);
            try
            {
                repository.Update(instance);
                result.Success = true;
            }
            catch(Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public IResult Delete(string couponID)
        {
            IResult result = new Result(false);

            if (!this.IsExists(couponID))
            {
                result.Message = "找不到資料";
            }

            try
            {
                var instance = this.GetByID(couponID);
                this.repository.Delete(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public IEnumerable<Coupons> GetAll()
        {
          return repository.GetAll();
        }

        public Coupons GetByID(string couponID)
        {
            return this.repository.Get(x => x.CouponId == couponID);
        }

        public IEnumerable<Coupons> GetConponByRAccount(string r_id)
        {
            return repository.GetAllById(x => x.R_Id == r_id).ToList();
        }

        public bool IsExists(string couponID)
        {
            return this.repository.GetAll().Any(x => x.CouponId == couponID);
        }

        
    }
}