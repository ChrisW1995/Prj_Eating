using Eating.Interface;
using Eating.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eating.ViewModels;

namespace Eating.Service.Interface
{
    interface IReserveService
    {
        IResult Create(Reserves instance);

        IResult Update(Reserves instance);

        IResult Delete(int reserveID);

        bool IsExists(int reserveID);

        Reserves GetByID(int reserveID);

        IEnumerable<Reserves> GetAll();

        IEnumerable<ReserveViewModel> GetReserveListByRAccount(string r_id, IEnumerable<Reserves> Reserves);
        //  IEnumerable<Reserves> GetConponByRAccount(string r_Account);
    }
}
