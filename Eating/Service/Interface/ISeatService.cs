using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eating.Interface;
using Eating.Models;

namespace Eating.Service.Interface
{
    public interface ISeatService
    {
        IResult Create(Seat instance);

        IResult Update(Seat instance);

        IResult Delete(int? SeatID);

        bool IsExists(int? SeatID);

        Seat GetByID(int? SeatID);

        IEnumerable<Seat> GetAll();

        IEnumerable<Seat> GetSeatByRAccount(string r_Account);
    }
}
