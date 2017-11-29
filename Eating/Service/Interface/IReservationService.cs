using Eating.Interface;
using Eating.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eating.ViewModels;
using Eating.DTOs;

namespace Eating.Service.Interface
{
    interface IReservationService
    {

        IResult CreateTime(SetReservationDetails instance);

        IResult Create(Reservations instance);

        IResult Update(Reservations instance);

        IResult Delete(int reserveID);

        IResult DelSetTimes(SetReservationDetails instance);
        bool IsExists(int reserveID);

        IEnumerable<SetReservationTimeViewModel> GetSettingList(string r_id);

        IEnumerable<SetReservationDetails> GetSettingList(string r_id, TimeSpan time);

        IEnumerable<ReservationTimeDTO> GetReservationTime(DateTime date, int peopleNum, bool isSomke, string r_id);
        Reservations GetByID(int reserveID);

        SetReservationDetails GetSetTime(int id);
        IEnumerable<Reservations> GetList();

        IEnumerable<ReserveViewModel> GetReserveListByRAccount(string r_id, IEnumerable<Reservations> Reserves);
        //  IEnumerable<Reserves> GetConponByRAccount(string r_Account);
    }
}
