using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Eating.Models;
using System.Threading.Tasks;
using Eating.Interface;

namespace Eating.Service.Interface
{
   public interface ICouponService
    {
        IResult Create(Coupons instance);

        IResult Update(Coupons instance);

        IResult Delete(string couponID);

        bool IsExists(string couponID);

        Coupons  GetByID(string couponID);

        IEnumerable<Coupons> GetAll();

        IEnumerable<Coupons> GetConponByRAccount(string r_Account);
    }
}
